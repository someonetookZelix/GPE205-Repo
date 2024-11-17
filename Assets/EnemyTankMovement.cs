using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{
    public GameObject[] tanks;
    private NavMeshAgent agent;
    public int setrange;
    public float setspeed;

    public GameObject self;

    private Transform centerPoint;

    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tanks[0], transform.position, Quaternion.identity, self.transform);
        Instantiate(tanks[1], transform.position, Quaternion.identity, self.transform);
        Instantiate(tanks[2], transform.position, Quaternion.identity, self.transform);
        Instantiate(tanks[3], transform.position, Quaternion.identity, self.transform);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < tanks.Length; i++)
        {
            target = tanks[i];
        }
    }
}
