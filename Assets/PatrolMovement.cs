using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{

    public Transform[] patrolPoints;
    private Transform patrolPointParent;
    int currentPoint;

    UnityEngine.AI.NavMeshAgent agent;

    float currentWait;
    float maxWait;
    private float speed;
    public GameObject parent;
    private Transform player;
    private bool hunt;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentPoint = -1;
        currentWait = 0;
        maxWait = 0;
        speed = parent.GetComponent<EnemyTankMovement>().setspeed;
        parent = GameObject.FindGameObjectWithTag("TankParent");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        patrolPointParent = GameObject.FindGameObjectWithTag("PatrolPointParent").GetComponent<Transform>();
        patrolPoints[0] = patrolPointParent.transform.GetChild(0).gameObject.GetComponent<Transform>();
        patrolPoints[1] = patrolPointParent.transform.GetChild(1).gameObject.GetComponent<Transform>();
        patrolPoints[2] = patrolPointParent.transform.GetChild(2).gameObject.GetComponent<Transform>();
        patrolPoints[3] = patrolPointParent.transform.GetChild(3).gameObject.GetComponent<Transform>();
        agent.speed = speed;

        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        LookForPlayer();

        if(hunt == true)
        {
            GoToTarget();
        }
        else
        {
            if(agent.remainingDistance <= 0.5f)
            {
                if(maxWait == 0)
                {
                    maxWait = Random.Range(1, 3);
                }
                if(currentWait >= maxWait)
                {
                    maxWait = 0;
                    currentWait = 0;
                    GoToNextPoint();
                }
                else
                {
                    currentWait += Time.deltaTime;
                }
            }
        }
    }

    void GoToNextPoint()
    {
        if(patrolPoints.Length != 0)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }

    void LookForPlayer()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20) && hit.collider.tag == "Player")
        {
            Debug.DrawLine(transform.position, transform.forward * hit.distance, Color.red);
            hunt = true;
        }
        else
        {
            Debug.DrawLine(transform.position, transform.forward * 20, Color.blue);
            hunt = false;
        }
    }

    void GoToTarget()
    {
            agent.SetDestination(player.position);
    }
}
