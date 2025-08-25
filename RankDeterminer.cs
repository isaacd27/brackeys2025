using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEditor.ShaderGraph.Internal;
public class RankDeterminer : MonoBehaviour
{

    public GameObject player;
    public TMP_Text rank;

    //SetSavedVariable SScore;
    float score;
    string ranktext = "NO RANK";
    // Start is called before the first frame update
    public static RankDeterminer Instance;
    private void Awake()
    {
        //code for making sure there are no copies
        //i forget how it is supposed to work
        // so  i'm disabing it for now

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    
    }
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        PlayerController playerController = player.GetComponent<PlayerController>();


        score = playerController.getscore();

        if (rank == null)
        {
            if (GameObject.Find("RankText").GetComponent<TMP_Text>() != null)
            {
                rank = GameObject.Find("RankText").GetComponent<TMP_Text>();
            }
        }
        //might need to move to update
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("SampleScene"))
        {
            if (rank == null)
            {
                if (GameObject.Find("RankText").GetComponent<TMP_Text>() != null)
                {
                    rank = GameObject.Find("RankText").GetComponent<TMP_Text>();
                }
                else
                {
                    return;
                }
            }
            else
            {
                rank.text = "Your rank is: " + ranktext;
                /*
                switch score{

                    case score == 5000000;


                        break;



                }*/

                if (score == 5000000)
                {
                    ranktext = "PERFECT BISCUIT!";
                }
                else if (score < 5000000 && score >= 4500000)
                {
                    ranktext = "NEARLY PERFECT BISCUIT!";
                }
                else if (score < 4500000 && score >= 4000000)
                {
                    ranktext = "REGULAR BISCUIT!";
                }
                else if (score < 4000000 && score >= 3500000)
                {
                    ranktext = "FLAWED BISCUIT.";
                }
                else if (score < 3500000 && score >= 3000000)
                {
                    ranktext = "FLAVORLESS BISCUIT.";
                }
                else if (score < 3000000 && score >= 2500000)
                {
                    ranktext = "EXPIRED BISCUIT.";
                }
                else if (score < 2500000 && score >= 2000000)
                {
                    ranktext = "ANCIENT BISCUIT(expired 1602).";
                }
                else if (score < 2000000 && score > 1500000)
                {
                    ranktext = "DOG BISCUIT.";
                }
                else if (score < 1500000 && score >= 1000000)
                {
                    ranktext = "EXPIRED DOG BISCUIT.";
                }
                else if (score < 1000000 && score >= 500000)
                {
                    ranktext = "NO BISCUIT. =(";
                }
                else if (score < 500000 && score > 0)
                {
                    ranktext = "BANNED FROM BISCUITS(you can never eat one again). =(";
                }
                else if (score == 0)
                {
                    ranktext = "DISQUALIFIED.";
                }
                else if (score < 0 && score > float.MinValue)
                {
                    ranktext = "NEGATIVE BISCUIT(you now owe a biscuit to  the hosts).";
                }
                else if (score == float.MinValue)
                {
                    ranktext = "HONESTLY IMPRESSED (you definitely did this on purpose).";
                }
                else
                {
                    ranktext = "FLAGRANT ERROR, PLEASE REPORT.";
                }
                
            
                
                


            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            score = player.GetComponent<PlayerController>().getscore();
            //SceneManager.LoadScene(4);
        }
        
        //move to finale screen


        //SScore = score;
    }
}
