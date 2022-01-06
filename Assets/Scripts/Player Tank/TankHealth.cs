using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    private TankController tankController;
    public HealthBar healthBar;

    private float maxHealth;
    private float currentHealth;

    private void Start()
    {
        maxHealth = tankController.setMaxHealth();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(20);
        }
    }

    private void takeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.setCurrentHealth(currentHealth);
    }
}