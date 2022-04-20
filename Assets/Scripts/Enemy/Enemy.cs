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
public int enemyCounter = 0;

    void Start()
    {
        currentHealth = maxHealth;
        // int randomIndex = Random.Range(0, myObjects.Length);
        //  Spawn();
        for (int i = 0; i < 5; i++)
        {
            GameObject go=Instantiate(myObjects) as GameObject;
            // go.transform.parent = GameObject.Find("Enemy").transform;
        }
        

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

        //play hurt animation
        animator.SetTrigger("Hurt");

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
        GetComponent<EnemyCombat>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        Instantiate(coin, transform.position, transform.rotation);
        // Instantiate(coin, new Vector3(0, 0, 0), Quaternion.identity);

    }

    


}
