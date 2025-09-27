using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider healthSlider;

    public float health;
    public float maxHealth = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }


    public void OnDamage(float amount)
    {
        health -= amount;
        healthSlider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
