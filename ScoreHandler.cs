using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHandler : MonoBehaviour
{
    public GameObject player;
    public TMP_Text scoretext;

    string scoretextText;
    
    void Start()
    {
        //if player is not set, will set it as the first object tagged 'player'
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        scoretextText = "Score: " + player.GetComponent<PlayerController>().getscore().ToString();

        scoretext.text = scoretextText;
    }
}
