using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UIElements;

public class LSaw : MonoBehaviour
{

    bool left;
    public float xtop;
    public float xbottom;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          transform.Rotate(Vector3.forward,speed *100* Time.deltaTime,Space.Self);
        if (left)
        {
            
            if (transform.position.x > xtop)
            {
            
                transform.Translate(UnityEngine.Vector2.left * Time.deltaTime * speed, Space.World);
                //transform.position.y = transform.position.y - speed* Time.deltaTime;
            }
            else if (transform.position.x <= xtop)
            {
                left = false;
            }
        }
        else
        {
            if (transform.position.x < xbottom)
            {
            
                transform.Translate(UnityEngine.Vector2.right * Time.deltaTime * speed,Space.World);
            }
            else if (transform.position.x >= xbottom)
            {
                
                left = true;
            }
        }
    }
}
