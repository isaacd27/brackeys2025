using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class UpDownPlat : MonoBehaviour
{

    bool up;
    public float ytop;
    public float ybottom;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            if (transform.position.y < ytop)
            {
                transform.Translate(UnityEngine.Vector2.up * Time.deltaTime * speed);
                //transform.position.y = transform.position.y - speed* Time.deltaTime;
            }
            else if (transform.position.y >= ytop)
            {
                up = false;
            }
        }
        else
        {
            if (transform.position.y > ybottom)
            {
                transform.Translate(UnityEngine.Vector2.down * Time.deltaTime * speed);
            }
            else if (transform.position.y <= ybottom)
            {
                up = true;
            }
        }
    }
}
