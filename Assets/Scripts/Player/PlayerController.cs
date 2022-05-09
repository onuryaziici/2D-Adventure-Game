using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    public float speedAmount=5f;
    public float jumpAmount=5f;
    public Animator animator;
    public Animator chestanimator;
    public bool canMove;
    public GameObject heart;
    //  bool isCreated=false;
    
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"),0f);
        if (canMove)
        {
             transform.position += velocity * speedAmount * Time.deltaTime;
        }
       
        animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));

        // if(Input.GetButtonDown("Jump")  && !animator.GetBool("IsJumping") )
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ) && !animator.GetBool("IsJumping") && canMove )
        {
            rgb.AddForce(Vector3.up*jumpAmount,ForceMode2D.Impulse);
            animator.SetBool("IsJumping",true);
        }
        
        if(Input.GetAxisRaw("Horizontal")== -1)
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }

        else if(Input.GetAxisRaw("Horizontal")== 1)
        {
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }

       
        
      
    }

     private void OnCollisionEnter2D(Collision2D collision) 
        {
            if(collision.gameObject.name== "Ground")
            {
                
                animator.SetBool("IsJumping",false);
            }
               
                if(collision.gameObject.tag== "Chest")
                {
                     
                    chestanimator.SetBool("IsAround",true);
                        // bool isCreated=false;
                        //  if(!isCreated)
                        //  {
                             
                        //     Instantiate(heart, transform.position+new Vector3(5f,0f,0f), transform.rotation);
                        //     isCreated = true;
                        //     }
                }

                if(collision.gameObject.tag== "Statue")
                {
                    
                    Debug.Log("Game Finished");
                }


        }
    private void OnCollisionExit2D(Collision2D collision) 
        {
            if(collision.gameObject.name== "Ground")
            {
                animator.SetBool("IsJumping",true);
            }
        }

            // private void OnTriggerEnter2D(Collider2D other)
            // {
               
            //     if(other.gameObject.tag== "Chest")
            //     {   
                    
            //         if(!isCreated)
            //         {
            //             Instantiate(heart, transform.position+new Vector3(7f,0f,0f), transform.rotation);
            //             isCreated = true;
            //         }
                    
            //         chestanimator.SetBool("IsAround",true);
            //     }
             
            // }
            // private void OnTriggerExit2D(Collider2D other)
            // {
            //     if(other.gameObject.tag== "Chest")
            //     {
                    
            //          chestanimator.SetBool("IsAround",false);
            //     }
             
            // }
            


}
