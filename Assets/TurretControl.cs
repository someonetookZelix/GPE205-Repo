using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public GameObject parent;
    private float speed;
    private int range;
    private Transform player;
    private bool hunt;
    UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        range = parent.GetComponent<EnemyTankMovement>().setrange;
        speed = parent.GetComponent<EnemyTankMovement>().setspeed;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        parent = GameObject.FindGameObjectWithTag("TankParent");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            transform.Rotate(Vector3.up * 10 * Time.deltaTime * speed, Space.World);
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
            Debug.DrawLine(transform.position, transform.forward * 20, Color.magenta);
            hunt = false;
        }
    }

    void GoToTarget()
    {
            agent.SetDestination(player.position);
    }
}
