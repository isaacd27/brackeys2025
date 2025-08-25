using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    // Set variables for player input and speed
    public bool isdead = false;
    public float speed = 1.0f;
    public float horizontalInput;

    bool canplace = true;
    public bool faceleft;
    public float size = 1.0f;

    // Set Variables for player jump and fall
    public float jumpForce = 10.25f;
    bool isGrounded;
    bool isFalling;
    bool hasLanded;

    public UnityEngine.Vector3 checkpoint;
    private Rigidbody2D rb;

    public float score = 5000000;

    // Set Boundaries
    public float yBoundary = 15.0f;
    //public float Ytop = 60f;

    //References
    public UIbehaviour uIbehaviour;
    public Animator anim;
    private bool isPaused;


    public float getscore()
    {
        return score;
    }

    public void SetYbound(float y)
    {
        yBoundary = y;
    }

    public float getYbound()
    {
        return yBoundary;
    }

    public void setcheck(UnityEngine.Vector3 cp)
    {
        checkpoint = cp;
    }

    void Start()
    {
        // Access player's Rigidbody
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        //Cursor.visible = false;
        isPaused = false;
        hasLanded = true;
        checkpoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //controls shouldn't work while dead by adding an if(!isdead) surrounding

    
    


        if (Input.GetKeyDown(KeyCode.Z) )
        {
            if (isGrounded && canplace)
            {
                if (checkpoint != transform.position)
                {
                    score -= 50;
                    checkpoint = this.transform.position;
                }
                
            }
        
        }


        if (Input.GetKeyDown(KeyCode.X))
        {
        
        }

        

        Move();

        if (!faceleft)
        {
            transform.localScale = new UnityEngine.Vector2(1 * size, size);
        }
        else
        {
            transform.localScale = new UnityEngine.Vector2(-1 * size, size);
        }

        // set function for fall out of boundary
        if (transform.position.y < -yBoundary)
        {
            // when you fall below the y boundary you go to the top
            score -= 100;
            transform.position = checkpoint;
            isGrounded = true;
        }
        
        
        

        // Jump method
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            // audioManager.playSFX("Jump");

            //may need jumpforce *1000
            //Debug.Log("Boing");
            rb.AddForce(UnityEngine.Vector2.up * jumpForce*1000, ForceMode2D.Force);
            isGrounded = false;
            hasLanded = false;
        }

        // set Jumping bool in animator as opposite of isGrounded bool

        anim.SetBool("Jumping", !isGrounded);

        // Falling method
        if (rb.velocity.y < 0)
        {
            isFalling = true;
        }
        else
        {
            if (isFalling && !hasLanded)
            {
                hasLanded = true;
                //audioManager.playSFX("Land");
            }
            isFalling = false;
        }

        // set Falling bool in animator as isFalling bool
        //anim.SetBool("Falling", isFalling);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                uIbehaviour.Pause();
                Cursor.visible = true;
                isPaused = true;
            }
            else
            {
                uIbehaviour.Resume();
                Cursor.visible = false;
                isPaused = false;
            }

        }
    }

    public void Move()
    {
        // set horizontal input and translate player movement
        horizontalInput = Input.GetAxis("Horizontal");
        //add /size to add a feeling of weight to being bigger
        transform.Translate(UnityEngine.Vector2.right * Time.deltaTime * horizontalInput * speed);
        int H = (int)horizontalInput;
        // set SpeedX in animator as absolute value of horizontal input


        // face the player sprite in the correct direction
        if (horizontalInput > 0.001f)
        {
            H = 1;
            transform.localScale = new UnityEngine.Vector2(1 * size, size);
            faceleft = false;
        }
        else if (horizontalInput < -0.001f)
        {
            H = -1;
            transform.localScale = new UnityEngine.Vector2(-1 * size, size);
            faceleft = true;
        }
        else
        {
            H = 0;
        }
        
        anim.SetInteger("H",H);
    }

    public void SpawnSlimeBall()
    {
        //fakeSlimeBallInst = Instantiate(fakeSlimeBall, transform.transform.position, Quaternion.identity);
    }

    #region Collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            //play death sfx
            score -= 100;
            this.transform.position = checkpoint;
            isFalling = false;
            isGrounded = true;
            //lower score
        }

    if (collision.gameObject.tag == "NoCheck")
        {
            Debug.Log("Noplace");
            canplace = false;
        }

        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NoCheck")
        {
            Debug.Log("Canplace");
            canplace = true;
        }
    }

    // simple ground detection
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {


            isGrounded = true;

        }
        

        
    }
            
    

    #endregion

    





    public void die()
    {
        //isdead = true;
    }

}
