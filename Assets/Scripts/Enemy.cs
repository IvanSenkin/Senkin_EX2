using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _maxHP;
    [SerializeField] private GameObject _item1;
    [SerializeField] private GameObject _item2;
    [SerializeField] private GameObject _item3;
    [SerializeField] private GameObject _spawnSpot;
    [SerializeField] private Transform _target;
    [SerializeField] private float _checkDinstanseToPlayer;
    
    private GameObject randomItem;
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    public static bool enemyFire;
    private float random;
    private int _hp;
    private int m_CurrentWaypointIndex;

    private void Awake()
    {
        _hp = _maxHP;
        navMeshAgent.GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[1].position);
    }
    void Update()
    {
        RandomItems();
        EnemyPatrol();
    }

    private void EnemyPatrol()
    {
        if (_checkDinstanseToPlayer >= Vector3.Distance(transform.position, _target.position))
        {
            navMeshAgent.SetDestination(_target.position);
            _animator.SetTrigger("Fire");
            enemyFire = true;
        }
        else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            enemyFire = false;
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("EnemyAuch!");
        _hp -= damage;

        if (_hp <= 0)
        {
            RandomItem3();
            Death();
            _animator.enabled = false;
        }
    }

    private void RandomItems()
    {
        if (Mathf.Approximately(random, 1))
        {
            randomItem = _item1;
        }
        else if (Mathf.Approximately(random, 2))
        {
            randomItem = _item2;
        }
        else
        {
            randomItem = _item3;
        }
    }

    private void RandomItem3()
    {
        if (randomItem = _item3)
        {
            for (int i = 0; i < Random.Range(0, 5); i++)
            {
                Instantiate(_item3, _spawnSpot.transform.position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(randomItem, _spawnSpot.transform.position, Quaternion.identity);
        }
    }

    private void Death()
    {        
        Destroy(gameObject, 3f);
    }
    public void Init(Transform target)
    {
        _target = target;
    }
}

