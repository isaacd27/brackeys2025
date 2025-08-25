using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject player;

    PlayerController PC;
    // Start is called before the first frame update
    void Start()
    {
        //if player is not set, will set it as the first object tagged 'player'
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    PC  = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PC.checkpoint;
    }
}
