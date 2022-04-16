using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float activeDistance=3f;
    public Animator animator;
    
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange=0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime=0f;
     public Transform target;
     public bool distan;
     public Player player;
     public int ch;

    // Update is called once per frame
    void Update()
    {
        ch=player.currentHealth;
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
}
