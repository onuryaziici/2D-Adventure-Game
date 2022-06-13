using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public Button AttackButton;
    public EventTrigger DefanseButton;
  

    // Update is called once per frame
    void Start() {
    {
      	Button btn = AttackButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        EventTrigger trigger = DefanseButton.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener( ( data ) => { OnPointerDown( ( PointerEventData ) data ); } );
        trigger.triggers.Add( entry );
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
		entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener( ( data ) => { OnPointerUp( ( PointerEventData ) data ); } );
        trigger.triggers.Add( entry2 );
    }
    }
    	void TaskOnClick()
        {
		    Attack();
	    }
        void OnPointerDown(PointerEventData data )
        {
		    playerContoller.canMove=false;
            Defense();
	    }
        void OnPointerUp(PointerEventData data)
        {
		    playerContoller.canMove=true;
            animator.SetBool("Shield",false);
            defenseStatus=false;
	    }

    void Update()
    {
        // if(Time.time >= nextAttackTime)
        // {
        //     if(Input.GetButtonDown("Jump"))
        //     {
        //         Attack();
        //         nextAttackTime = Time.time + 1f / attackRate;

        //     }
        // }

        // if (Input.GetKeyDown("h"))
        // {
        //     playerContoller.canMove=false;
        //     Defense();
        // }
        // else if(Input.GetKeyUp("h"))
        // {
        //     playerContoller.canMove=true;
        //     animator.SetBool("Shield",false);
        //     defenseStatus=false;
        // }


       
    }

    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            Collider2D[]  hitBoss= Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers2);
            foreach(Collider2D enemy in hitBoss)
            {
                enemy.GetComponent<Boss>().TakeDamage(attackDamage);
                
            }
            FindObjectOfType<AudioManager>().Play("Attack");
            animator.SetTrigger("Attack");
            Collider2D[]  hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                
            }        
            nextAttackTime = Time.time + 1f / attackRate;
        }



    }

    

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);

    }

    public void Defense()
    {
        
  
        animator.SetBool("Shield",true);
        defenseStatus=true;
        animator.SetTrigger("Defense");
        
    }
    public void DefenseOff()
    {
            playerContoller.canMove=true;
            animator.SetBool("Shield",false);
            defenseStatus=false;
    }


        
}
