using UnityEngine;

public class Delation : MonoBehaviour
{
    public float timeLimit = 10;
    public float timePassed = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= timeLimit) Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyMovement>();

            // Bring back speed a second before the zone is done
            if (timeLimit - 1 < timePassed)
            {
                enemy.RevertSpeed();
            }
            else if (enemy != null)
            {
                enemy.ReduceSpeed();
            }


        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyMovement>();

            if (enemy != null)
            {
                enemy.RevertSpeed();
            }
        }
    }
}
