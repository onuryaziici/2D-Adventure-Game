using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
     public int maxHealth = 100;
    public int currentHealth;
    public bool IsDead=false;
    public HealthBar healthBar;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        // GetComponent<PlayerCombat>().defenseStatus;
        if (!(GetComponent<PlayerCombat>().defenseStatus))
        {
            currentHealth -=damage;
            // healthBar.SetHealth(currentHealth);
        }
        
        

        //play hurt animation
        // animator.SetTrigger("Hurt");

        if(currentHealth<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Player died !");
        //die animation
         animator.SetBool("IsDead",true);
        //disable the enemy
        // GetComponent<Collider2D>().enabled = false;
         this.enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag==("Coin"))
        {
            Debug.Log("Triggered");
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag==("Heart"))
        {
            currentHealth=currentHealth+20;
            if(currentHealth>maxHealth)
            {currentHealth=maxHealth;}
            Destroy(other.gameObject);
        }


                    
                            
        
    }
}
