using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float attackDistance;

    private NavMeshAgent agent;
    private float distance;

    private bool attackPlayer { get; set; } = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        if (attackPlayer) // Attack player once anomoly affects
        {
            distance = Vector3.Distance(agent.transform.position, playerTransform.position);
            if (distance < attackDistance)
            {
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
                agent.destination = playerTransform.position;
                transform.LookAt(playerTransform.position, Vector3.up);
            }
        }
    }


    public void OnAttackPlayer()
    {
        attackPlayer = true;
    }
}
