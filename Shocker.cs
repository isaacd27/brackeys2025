using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Shocker : MonoBehaviour
{

    public float interval;
    float timer = 0;
    bool on;

    public Animator anim;

    public BoxCollider2D zap;
    UnityEngine.Vector2 onsize;
    // Start is called before the first frame update
    void Start()
    {

        if (zap == null)
        {
            UnityEngine.Debug.LogError("No Box Collider");

        }
        onsize = zap.size;
       /// zap.size = UnityEngine.Vector2.zero;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("On", on);



        if (on)
        {
            //make zap exist 
            if (timer < interval)
            {
                timer += Time.deltaTime;
                this.gameObject.tag = "Respawn";
                //
            }
            else
            {
                on = false;
            }
        }
        else
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                this.gameObject.tag = "Ground";
                //
            }
            else
            {
                on = true;
            }
        }
    }
}
