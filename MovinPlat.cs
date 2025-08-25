using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MovinPlat : MonoBehaviour
{

    bool move = false;

    public float speed = 5f;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (this.transform.position.x > target.x)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
            else if (transform.position.x < target.x)
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            }

            if (this.transform.position.y > target.y)
            {
                transform.Translate(UnityEngine.Vector2.down * Time.deltaTime * speed);
            }
            else if (this.transform.position.y < target.y)
            {
                transform.Translate(UnityEngine.Vector2.up * Time.deltaTime * speed);
            }

            if (transform.position == target)
            {
                move = false;
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //this debug line is never printed
        UnityEngine.Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("touch");
            move = true;
        }
    }
}
