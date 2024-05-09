using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;
    public int iniitialHealth = 50;
     public SpriteRenderer deathSpriteRenderer;
    public Sprite deathEffect;
    public float deathTime = 0f;
    public void TakeDamage (int damage)
     {
        health -= damage;

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }
   IEnumerator Die()
   {

    if (deathSpriteRenderer != null && deathEffect != null)
    {
    deathSpriteRenderer.sprite = deathEffect;
    yield return new WaitForSeconds(deathTime);

    Destroy(gameObject);
    }
   }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
