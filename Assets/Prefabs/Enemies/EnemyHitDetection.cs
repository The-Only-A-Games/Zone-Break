using UnityEngine;
using UnityEngine.UI;

public class EnemyHitDetection : MonoBehaviour
{
    public float hitDamage = 2f;
    public GameManager gameManager;
    public Slider slider;

    public float health;
    public float maxHealth = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnHit()
    {
        health -= hitDamage;
        slider.value = health;

        if (health <= 0)
        {
            gameManager.OnEnemyKill();
            Destroy(gameObject);
        }
    }
}
