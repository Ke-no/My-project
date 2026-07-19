using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    
    [SerializeField]
    private Transform targetToChase;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        if(navMeshAgent != null && targetToChase != null)
        {
            navMeshAgent.SetDestination(targetToChase.position);
        }
    }
}
