using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public GameObject coin;
    public GameObject myObjects;
      int maxEnemies = 3;
      public bool hurt=false;
       public HealthBar healthBar;
       public Canvas canvas1;
public int enemyCounter = 0;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        // int randomIndex = Random.Range(0, myObjects.Length);
        //  Spawn();

        //enemy spawn

        // for (int i = 0; i < 5; i++)
        // {
        //     GameObject go=Instantiate(myObjects) as GameObject;
        //     // go.transform.parent = GameObject.Find("Enemy").transform;
        // }
        

    }

    void Update()
    {
       
    }
    void Spawn()
    {
        
           if(enemyCounter < maxEnemies)
           {
                Instantiate(myObjects, new Vector3(0,-2.62f,0f), Quaternion.identity);
                enemyCounter++;
                }
        
    }

    // void Update() 
    // {
       
    //     float x;
    //     x = Random.Range (0, 30);
    //     if (a<=5)
    //     {
    //         Debug.Log(a+" tane oluşturuldu");
    //         a=a+1;
    //         GameObject instantiatedObject = Instantiate(myObjects, new Vector3(x,-2.62f,0f), Quaternion.identity) as GameObject;
    //     }
        
    // }

    public void TakeDamage(int damage)
    {
        currentHealth -=damage;
        healthBar.SetHealth(currentHealth);
        

        //play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth<=0)
        {
            Die();
        }
        

    }

    void Die()
    {
        //die animation
        animator.SetBool("IsDead",true);
        //disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent<EnemyCombat>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        canvas1.gameObject.SetActive(false);
        // Instantiate(coin, transform.position, transform.rotation);
        Instantiate(coin, new Vector3(transform.position.x, -2.5f, 0), transform.rotation);
        // Instantiate(coin, new Vector3(0, 0, 0), Quaternion.identity);

    }

    


}
