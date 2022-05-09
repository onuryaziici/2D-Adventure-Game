using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public float activeDistance=3f;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange=0.5f;
    public int attackDamage = 20;
    public float attackRate = 1f;
    float nextAttackTime=0f;
    public bool distan;
    public Transform target;
    public Player player;
    public GameObject player1;
    public Canvas canvas1;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player1 = GameObject.FindWithTag("Player");  
        target = player1.transform;
        player=GameObject.FindWithTag("Player").GetComponent<Player>(); 
    }
    void Update()
    {
        distan=TargetInDistance();
        if(Time.time >= nextAttackTime)
        {
            if(TargetInDistance()&& player.currentHealth>0)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

            }
            
        }
    }

    void Attack()
    {
        Debug.Log("Attacked");
         animator.SetTrigger("Attack");
        Collider2D[]  hitPlayers= Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach(Collider2D player in hitPlayers)
        {
            player.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
    
    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);

    }
        private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.position)< activeDistance;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -=damage;
         healthBar.SetHealth(currentHealth);
        

        //play hurt animation
        // animator.SetTrigger("Hurt");

        if(currentHealth<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died !");
        //die animation
        animator.SetBool("IsDead",true);
        //disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        canvas1.gameObject.SetActive(false);
       

    }
}
