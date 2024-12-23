using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private bool canChase;

    [SerializeField] private float detectionRadius;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float requiredDistance;
    [SerializeField] private float attackDistance;

    [SerializeField] private Transform playerPosition;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform[] wayPoints;

    [SerializeField]
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        CalculatedNewPoint();
    }

    private void Update()
    {
        if(canChase == true)
        {
            float distance = Vector3.SqrMagnitude(playerPosition.position - transform.position);
            if (distance > detectionRadius * detectionRadius)
            {
                agent.speed = patrolSpeed;
            }
            else
            {
                if(distance > attackDistance)
                {
                    NavMeshPath path = new NavMeshPath();
                    agent.CalculatePath(playerPosition.position, path);

                    if (path.status == NavMeshPathStatus.PathComplete)
                    {
                        agent.speed = chaseSpeed;
                        agent.destination = playerPosition.position;
                    }
                    else
                    {
                        agent.ResetPath();
                    }
                }
                else
                {
                    Debug.Log("Attack");
                }
            }
        }

        Debug.Log("!pathpending:= " + !agent.pathPending);
        if (!agent.pathPending && agent.remainingDistance < requiredDistance)
        {
            CalculatedNewPoint();
        }
    }

    public void SetChase(bool newChaseStatus)
    {
        canChase = newChaseStatus;
    }

    protected override void Died()
    {
        base.Died();
        Destroy(gameObject);
    }

    private void MoveToPoint(Vector3 targetPosition)
    {
        agent.destination = targetPosition;
    }

    private void CalculatedNewPoint()
    {
        MoveToPoint(wayPoints[Random.Range(0, wayPoints.Length)].position);
    }
}
