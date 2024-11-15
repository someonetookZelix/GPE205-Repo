using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    private int range;
    private float speed;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform centerPoint;

    public GameObject parent;
    public Transform player;
    private bool hunt;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        centerPoint = transform;
        range = parent.GetComponent<EnemyTankMovement>().setrange;
        speed = parent.GetComponent<EnemyTankMovement>().setspeed;
        agent.speed = speed;
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
            Vector3 point;
            if(RandomPoint(centerPoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range,  out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        UnityEngine.AI.NavMeshHit hit;
        if(UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    void LookForPlayer()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20))
        {
            Debug.DrawLine(transform.position, transform.forward * hit.distance, Color.red);
            hunt = true;
        }
        else
        {
            Debug.DrawLine(transform.position, transform.forward * 20, Color.green);
            hunt = false;
        }
    }

    void GoToTarget()
    {
            agent.SetDestination(player.position);
    }
}
