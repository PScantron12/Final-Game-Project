using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int health = 50;
    public int initialHealth = 50;
    public SpriteRenderer deathSpriteRenderer;
    public Sprite deathEffect;
    public float deathTime = 0.5f;  // Duration before loading the cutscene
    public string cutsceneSceneName = "VictoryScreenDeath";  // The name of the cutscene scene to load

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            StartCoroutine(DieAndLoadCutscene());
        }


    }

    IEnumerator DieAndLoadCutscene()
    {
        if (deathSpriteRenderer != null && deathEffect != null)
        {
            // Display death effect
            deathSpriteRenderer.sprite = deathEffect;
            yield return new WaitForSeconds(deathTime);  // Wait before loading the cutscene

        }

        SceneManager.LoadScene(cutsceneSceneName);
    }


    void Start()
    {
          // Reset health to full at the start
    }

    void Update()
    {
        
    }
}
