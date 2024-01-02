using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class HealthBarController : MonoBehaviour
{
    public Image healthBarImage;
    public float currentHealth;
    public float maxHealth = 100f;
    public TextMeshProUGUI healthText; // Reference to the TextMeshProUGUI component


    private void Start()
    {
        
        // SetInitialHealthBasedOnDifficulty();
        // UpdateHealthBar();

        currentHealth = HealthData.currentHealth;
        UpdateHealthBar();
    }

    public void Update(){
        // SetInitialHealthBasedOnDifficulty();
        // Debug.Log("Current health: " + HealthData.currentHealth);
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        float healthRatio = currentHealth / maxHealth;
        healthBarImage.fillAmount = healthRatio;
        healthText.text = currentHealth + " / " + maxHealth; // Update the TextMeshPro text
    }

    // Call this method to update health from other parts of your game
    public void ModifyHealth(float amount)
    {
        currentHealth += amount;
        HealthData.currentHealth = currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
        CheckHealth();
    }

    public void InitializeHealthBasedOnDifficulty() {
        SetInitialHealthBasedOnDifficulty();
        UpdateHealthBar();
    }

    public void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            FindObjectOfType<PlayerMovement>().HandleGameOver();
        }   
    }

    private void SetInitialHealthBasedOnDifficulty()
    {
        switch (DifficultyManager.CurrentDifficulty)
        {
            case "Easy":
                HealthData.currentHealth = currentHealth = maxHealth; // 100%
                break;
            case "Medium":
                HealthData.currentHealth = currentHealth = maxHealth * 0.7f; // 70%
                break;
            case "Hard":
                HealthData.currentHealth = currentHealth = maxHealth * 0.5f; // 50%
                break;
            default:
                HealthData.currentHealth = currentHealth = maxHealth; // Default to full health
                break;
        }
    }

}
