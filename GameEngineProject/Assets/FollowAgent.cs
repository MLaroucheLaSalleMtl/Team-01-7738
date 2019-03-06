using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowAgent : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 destination;
    private NavMeshAgent agent;

    [SerializeField] private float radius;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            agent.enabled = true;
        }

        
    }

    void Update()
    {
        // Update destination if the target moves one unit
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }
    }
}