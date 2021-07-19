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

    int m_CurrentWaypointIndex;
    private void Awake()
    {
        _hp = _maxHP;
        navMeshAgent.GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[1].position);
    }
    void Update()
    {
        if (_checkDinstanseToPlayer >= Vector3.Distance(transform.position, _target.position)) //наоборот не работает =)
        {
            navMeshAgent.SetDestination(_target.position);
        }
        else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex+1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Auch!");
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
    
}

