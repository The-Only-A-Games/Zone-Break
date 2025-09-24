using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed = 20f;
    public float distanceLimit = 10f;
    public float travelledDistance = 0f;


    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
    }


    void Update()
    {
        travelledDistance += Time.deltaTime;

        if (travelledDistance >= distanceLimit)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyHitDetection>();

            if (enemy != null) enemy.OnHit();

            Destroy(gameObject);
        }

        else if (other.CompareTag("Player") || other.CompareTag("Zone"))
        {
            Debug.Log("Why are you hitting youself");
        }

        else
        {
            Destroy(gameObject);
        }

    }

}
