using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;
    public Sprite deathEffect;

    public void TakeDamage (int damage)
     {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
   void Die ()
   {
    Instantiate(deathEffect, transform.position, Quaternion.identity);
    Destroy(gameObject);
   }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
