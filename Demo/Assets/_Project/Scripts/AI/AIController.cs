using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] [Range(1, 100)] private float _speed;
    [SerializeField] [Range(1, 100)] private float _radius;

    NavMeshAgent _agent;
    Animator _animator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        if (_agent != null)
        {
            _agent.speed = _speed;
            UpdateDestPoint();
        }
    }

    private void Update()
    {
        if (_agent != null && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            UpdateDestPoint();
        }
        else if (_animator != null)
        {
            _animator.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }

    private void UpdateDestPoint()
    {
        Vector3 destPoint = RandomNavMeshLocation();
       _agent.SetDestination(destPoint);
    }

    private Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * _radius;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, _radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
