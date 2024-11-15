using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntMovement : MonoBehaviour
{

    public Transform player;
    UnityEngine.AI.NavMeshAgent agent;
    private float speed;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        speed = parent.GetComponent<EnemyTankMovement>().setspeed;
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        LookForPlayer();
        GoToTarget();
    }

    void GoToTarget()
    {
            agent.SetDestination(player.position);
    }

    void LookForPlayer()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20))
        {
            Debug.DrawLine(transform.position, transform.forward * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.forward * 20, Color.green);
        }
    }
}
