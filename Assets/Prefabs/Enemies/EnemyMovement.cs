using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float attackDistance;

    private NavMeshAgent agent;
    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(agent.transform.position, playerTransform.position);
        if (distance < attackDistance)
        {
            // Enemy is close enough -> stop moving, attack phase could go here
            agent.isStopped = true;
        }
        else
        {
            // Enemy is too far -> keep moving toward the player
            agent.isStopped = false;
            agent.destination = playerTransform.position;
            transform.LookAt(playerTransform.position, Vector3.up);
        }
    }
}
