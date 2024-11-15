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

    private Transform centerPoint;

    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {

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
