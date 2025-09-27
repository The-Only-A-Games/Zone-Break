using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    private float captureSpeed;
    public Transform playerTransform;
    public float attackDistance;

    private NavMeshAgent agent;
    private float distance;



    private bool attackPlayer { get; set; } = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        captureSpeed = speed;
    }


    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(agent.transform.position, playerTransform.position);
        if (distance < attackDistance)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
            agent.speed = speed;
            agent.destination = playerTransform.position;
            transform.LookAt(playerTransform.position, Vector3.up);
        }
    }


    public void OnAttackPlayer()
    {
        attackPlayer = true;
    }

    public void ReduceSpeed()
    {
        speed = 1;
    }

    public void RevertSpeed()
    {
        speed = captureSpeed;
    }


    // void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log(collision.collider.name);
    //     if (collision.collider.tag == "Player")
    //     {
    //         var player = collision.collider.GetComponent<PlayerHealth>();
    //         Debug.Log("Found Player");
    //         Debug.Log(player);

    //         if (player != null)
    //         {
    //             player.OnDamage(1);
    //         }
    //     }
    // }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerHealth>();
            Debug.Log("Found Player");
            Debug.Log(player);

            if (player != null)
            {
                player.OnDamage(1);
            }
        }
    }
}
