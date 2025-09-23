using UnityEngine;

public class EnemyHitDetection : MonoBehaviour
{
    public float health = 10f;
    public float hitDamage = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }


    public void OnHit()
    {
        health -= hitDamage;
    }
}
