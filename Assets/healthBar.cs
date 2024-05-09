using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public EnemyHealth enemyHealth; // Reference to the enemy's health script
    public Image healthBarFill; // Reference to the UI Image representing the health bar

    void Update()
    {
        // Ensure that we have references to the enemy's health script and the UI Image
        if (enemyHealth == null || healthBarFill == null)
            return;

        // Calculate the health percentage
        float healthPercent = (float)enemyHealth.health / enemyHealth.iniitialHealth;

        // Update the fill amount of the health bar UI element
        healthBarFill.fillAmount = healthPercent;
    }
}
