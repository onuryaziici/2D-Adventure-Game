using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask enemyLayers2;
    public float attackRange=0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime=0f;
    public bool defenseStatus;
    public PlayerController playerContoller;
  

    // Update is called once per frame
    void Start() {
    {
      
    }
    }
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetButtonDown("Jump"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

            }
        }

        if (Input.GetKeyDown("h"))
        {
            playerContoller.canMove=false;
            Defense();
        }
        else if(Input.GetKeyUp("h"))
        {
            playerContoller.canMove=true;
            animator.SetBool("Shield",false);
            defenseStatus=false;
        }


       
    }

    void Attack()
    {
        Collider2D[]  hitBoss= Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers2);
        foreach(Collider2D enemy in hitBoss)
        {
            enemy.GetComponent<Boss>().TakeDamage(attackDamage);
            
        }

        animator.SetTrigger("Attack");
        Collider2D[]  hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            
        }


    }

    

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);

    }

    void Defense()
    {
        
  
        animator.SetBool("Shield",true);
        defenseStatus=true;
        animator.SetTrigger("Defense");
        
    }


        
}
