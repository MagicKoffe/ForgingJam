using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform currentTarget;
    EnemyShoot enemShoot;
    Transform player;
    NavMeshAgent _navMeshAgent;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemShoot = GetComponent<EnemyShoot>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTarget = enemShoot.currentTarget;
        if (currentTarget == null)
            return;

        _navMeshAgent.SetDestination(currentTarget.position);
    }
}
