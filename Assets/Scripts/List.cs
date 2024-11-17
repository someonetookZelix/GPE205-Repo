using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{

    public List<string> pawns;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        pawns = new List<string>();

        pawns.Add(player.name);

        Instantiate(player, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
