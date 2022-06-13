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
    public int coin;
    public GameObject gameOver;



    
    void Start()
    {
        // healthBar = GameObject.Find("/Canvas/Health bar").GetComponent<Health_bar>;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Time.timeScale=1f;
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
            animator.SetTrigger("Hurt");
            currentHealth -=damage;
            // healthBar.SetHealth(currentHealth);
        }
        // else
        // {
        //     FindObjectOfType<AudioManager>().Play("Block");
        // }
        
        

        //play hurt animation
        // animator.SetTrigger("Hurt");

        if(currentHealth<=0)
        {
            currentHealth=0;
            healthBar.SetHealth(0);
            Die();
        }
    }
    void Die()
    {
        // gameOver=GameObject.Find("GameOverScreen1");
       

        FindObjectOfType<AudioManager>().Play("Game Over");
        //die animation
         animator.SetBool("IsDead",true);
        //disable the enemy
        // GetComponent<Collider2D>().enabled = false;
         this.enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
                gameOver.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag==("Coin"))
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            coin=PlayerPrefs.GetInt("Coin")+1;
            PlayerPrefs.SetInt("Coin",coin);
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag==("Heart"))
        {
            FindObjectOfType<AudioManager>().Play("Health");
            currentHealth=currentHealth+20;
            if(currentHealth>maxHealth)
            {currentHealth=maxHealth;}
            Destroy(other.gameObject);
        }


                    
                            
        
    }
}
