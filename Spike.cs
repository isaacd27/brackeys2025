using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Collider2D C2D;
    public Animator animator;

    Vector3 startpos;

    bool active = true;


    public void deactivate()
    {
        active = false;
    }

    public void activate()
    {
        active = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (C2D == null)
        {
            C2D = GetComponent<Collider2D>();
        }

        startpos = C2D.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            animator.SetFloat("Speed", 1);
            C2D.transform.position = new Vector3(float.MaxValue, float.MaxValue);
            this.GameObject().tag = "Untagged";
        }
        else
        {
            animator.SetFloat("Speed", -1);
            C2D.transform.position = startpos;
            this.GameObject().tag = "Respawn";
        }
    }
}
