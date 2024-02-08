
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent navMeshAgent;
    private Vector3 wanderDestination;
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.5f)
        {

            SetRandomDestination();
        }
    }

    /*IEnumerator TeleportAndFacePlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportDelay);
            if (player != null)
            {
                Vector3 randomDirection = Random.insideUnitSphere * teleportRadius;
                randomDirection += player.position;
                Vector3 teleportPosition = CheckTeleportPosition(randomDirection, player.position, teleportRadius);
                NavMeshHit navHit;
                if (teleportPosition != Vector3.zero)
                {
                    //TP
                    nva.Warp(teleportPosition);

                    //LOOK
                    Vector3 lookDirection = player.position - transform.position;
                    lookDirection.y = 0f;
                    Quaternion rotation = Quaternion.LookRotation(lookDirection);
                    transform.rotation = rotation;

                }



            }

        }

    }*/
    Vector3 CheckTeleportPosition(Vector3 origin, Vector3 target, float radius)
    {
        Vector3 direction = target - origin;
        NavMeshHit hit;
        if (NavMesh.FindClosestEdge(target, out hit, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return Vector3.zero;

    }
    private void SetRandomDestination()
    {
        // Generate a random point within the specified wanderRadius
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit navMeshHit;
        NavMesh.SamplePosition(randomDirection, out navMeshHit, wanderRadius, NavMesh.AllAreas);

        // Set the new destination
        wanderDestination = navMeshHit.position;
        navMeshAgent.SetDestination(wanderDestination);
    }

}
