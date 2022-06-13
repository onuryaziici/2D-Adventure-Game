using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Animator chestanimator;
    public GameObject heart;
    bool isCreated=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
            {
               
                if(other.gameObject.tag== "Chest")
                {   
                    chestanimator.SetBool("IsAround",true);

                    if(!isCreated)
                    {
                        Instantiate(heart,new Vector3(transform.position.x+5f,-2.5f,0f), transform.rotation);
                        isCreated = true;
                    }
                }
             
            }
            private void OnTriggerExit2D(Collider2D other)
            {
                if(other.gameObject.tag== "Chest")
                {
                    
                     chestanimator.SetBool("IsAround",false);
                }
             
            }
}
