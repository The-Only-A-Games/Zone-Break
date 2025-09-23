using UnityEngine;

public class TheTwist : MonoBehaviour
{
    public float spawnTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= 3)
        {
            enabled = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyMovement>();

            if (enemy != null)
            {
                enemy.OnAttackPlayer();
            }
        }
    }
}

