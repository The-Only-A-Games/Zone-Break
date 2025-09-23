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
            Debug.Log(other.name);

            var enemy = other.GetComponent<EnemyHitDetection>();

            if (enemy != null) enemy.OnHit();

        }

        else if (other.CompareTag("Crystal"))
        {
            Debug.Log(other.name);

            var cystal = other.GetComponent<Cystal>();

            if (cystal != null) cystal.OnHit();
        }

        if (!other.CompareTag("Zone"))
        {
            Destroy(gameObject);
        }

    }

}
