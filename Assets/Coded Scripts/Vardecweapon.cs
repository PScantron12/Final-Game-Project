using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour
{
    public Transform firingPoint; // The point from which projectiles are launched
    public GameObject projectilePrefab; // The projectile prefab

    public SpriteRenderer spriteRenderer; // The SpriteRenderer component of the boss
    public Sprite defaultSprite; // Default sprite of the boss
    public Sprite chargingSprite; // Sprite when charging
    public Sprite shootingSprite; // Sprite when shooting

    private float attackRate = 3f; // The boss attacks every 5 seconds
    private float chargeTime = 1f; // Time spent charging
    private float shootTime = 0.5f; // Time spent in shoot animation

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            StartCoroutine(PerformAttack());
            nextAttackTime = Time.time + Random.Range(0.5f,1.25f);
        }
    }

    IEnumerator PerformAttack()
    {
        // Change to charging sprite
        spriteRenderer.sprite = chargingSprite;
        yield return new WaitForSeconds(chargeTime);

        // Change to shooting sprite and shoot the projectile
        spriteRenderer.sprite = shootingSprite;
        ShootProjectile();
        yield return new WaitForSeconds(shootTime);

        // Return to default sprite
        spriteRenderer.sprite = defaultSprite;
    }

    void ShootProjectile()
    {
        Instantiate(projectilePrefab, firingPoint.position, Quaternion.identity);
    }
}
