using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private Transform _target;
    [SerializeField] private float _checkDinstanseToPlayer;
    private int _hp;
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    [SerializeField] private Animator _animator;
    public bool enemyFire = false;
    int m_CurrentWaypointIndex;
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
        if (_checkDinstanseToPlayer >= Vector3.Distance(transform.position, _target.position)) 
        {
            navMeshAgent.SetDestination(_target.position);
            _animator.SetTrigger("Fire");
            enemyFire = true;
        }
        else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex+1) % waypoints.Length;
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
            Death();
        }
    }
    private void Death()
    {
        Destroy(gameObject);
    }
    public void Init(Transform target)
    {
        _target = target;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);

        //if (other.CompareTag("Sword"))
        //{
        //    TakeDamage(10);
        //    Debug.Log("-10 p.attack");
        //}
    }

}

