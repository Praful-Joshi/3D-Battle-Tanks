using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;
    public Image fillImage;
    public Color fullHealthColor = Color.green, zeroHealthColor = Color.red;
    public GameObject explosionPrefab;

    private AudioSource explosionAudioSource;
    private ParticleSystem explosionParticles;
    private float currentHealth;
    private float startingHealth;
    private bool dead;

    private void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudioSource = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        startingHealth = EnemyService.enemyModel.health;
        currentHealth = startingHealth;
        dead = false;
        setHealthUI();
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        setHealthUI();
        if (currentHealth <= 0f && !dead)
        {
            onDeath();
        }
    }

    private void onDeath()
    {
        dead = true;
        explosionParticles.transform.position = this.transform.position;
        explosionParticles.gameObject.SetActive(true);
        explosionParticles.Play();
        explosionAudioSource.Play();
        gameObject.SetActive(false);
    }

    private void setHealthUI()
    {
        healthSlider.value = currentHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth);
    }
}
