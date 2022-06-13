using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Joystick joystick;
    public float hizdurum =0f;
    public int nextSceneLoad;
    public int PlayerHangisi;
    public GameObject gameWin;
    // public CharacterSelect chaSelect;
    
    //  bool isCreated=false;
    
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // velocity = new Vector3(Input.GetAxis("Horizontal"),0f);
        // velocity = new Vector3(joystick.Horizontal,0f);
        if (joystick.Horizontal>=.2f)
        {
            hizdurum=1f;
            velocity=new Vector3(1,0f);
            if (canMove)
            {
                transform.position += velocity * speedAmount * Time.deltaTime;
            }
        }
        else if (joystick.Horizontal<=-.2f)
        {
            hizdurum=-1f;
            velocity=new Vector3(-1,0f);
            if (canMove)
            {
                transform.position += velocity * speedAmount * Time.deltaTime;
            }
        }
        else
        {
            hizdurum=0f;
        }

        animator.SetFloat("Speed",Mathf.Abs(hizdurum));

        // if(Input.GetButtonDown("Jump")  && !animator.GetBool("IsJumping") )
        float verticalMove =joystick.Vertical;
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)|| verticalMove>=.5f) && !animator.GetBool("IsJumping") && canMove )
        {
            rgb.AddForce(Vector3.up*jumpAmount,ForceMode2D.Impulse);
            animator.SetBool("IsJumping",true);
        }
        
        // if(Input.GetAxisRaw("Horizontal")== -1)
        if(joystick.Horizontal<0)
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }

        else if(joystick.Horizontal>0)
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
                    if (SceneManager.GetActiveScene().buildIndex==3)
                    {
                       Time.timeScale=0f;
                       gameWin.SetActive(true);
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().Play("LevelSuccess");
                        nextSceneLoad=SceneManager.GetActiveScene().buildIndex + 1;
                        PlayerPrefs.SetInt("levelReached",nextSceneLoad-1);
                        PlayerHangisi=PlayerPrefs.GetInt("SelectedCharacter");
                        SceneManager.LoadScene(nextSceneLoad);
                        // SceneManager.GetActiveScene().buildIndex;
                        PlayerPrefs.SetInt("SavedScene",2);
                    }


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
