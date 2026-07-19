using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float visionRange = 10f;

    private NavMeshAgent agent;
    private Vector3 startPosition;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (player == null)
        return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Detect player
        if (distance <= visionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // Chase or return
        if (isChasing)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(startPosition);
        }
    }

    // Draw range in Scene
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }   
}
