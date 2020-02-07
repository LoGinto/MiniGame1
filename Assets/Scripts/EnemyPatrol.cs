using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] EnemyWays enemyWay = null;
    int wayIndex = 0;
    Vector3 currentPos;
    Animator animator;
    NavMeshAgent navMeshagent;
    float timeSinceArrived = 0;
    public float nextPointTime = 3f;
    public float maxDistanceFromWaypoint = 1.5f;
    enemy eee;
    // Start is called before the first frame update
    void Start()
    {
        navMeshagent = GetComponent<NavMeshAgent>();
        currentPos = transform.position;
        animator = GetComponent<Animator>();
        eee = GetComponent<enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceArrived += Time.deltaTime;
        PatrolPath();
    }

    private void PatrolPath()
    {
        Vector3 nextPos = currentPos;
        if (!eee.ISChasing())
        {
            if (ISonWayPoint())
            {
                timeSinceArrived = 0;
                NextPoint();
            }
            nextPos = CurrentWayPointPos();
            if (timeSinceArrived > nextPointTime)
            {
                MoveTo(nextPos);

            }
        }
    }

    private void NextPoint()
    {
        wayIndex = enemyWay.GetNextIndexInLoop(wayIndex);
    }
    private Vector3 CurrentWayPointPos()
    {
        return enemyWay.GetEndpoint(wayIndex);
    }

    void MoveTo(Vector3 destination)
    {
        navMeshagent.destination = destination;
        navMeshagent.isStopped = false;
        
        if (!eee.ISChasing())
        {
            animator.SetBool("isWalking", true);
        }
    }
    bool ISonWayPoint()
    {
        float distanceToPath = Vector3.Distance(transform.position,CurrentWayPointPos());
        return distanceToPath < maxDistanceFromWaypoint;

    }
}
