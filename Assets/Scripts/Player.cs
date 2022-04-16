using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
     public int maxHealth = 100;
    public int currentHealth;
    public bool IsDead=false;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -=damage;

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
}
