using UnityEngine;
using UnityEngine.AI;

public class PatrolPath : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentIndex = 0;

    private NavMeshAgent agent;
    private Animator animator;

    public Transform player;
    public float viewDistance = 10f;
    public float viewAngle = 120f;
    public float chaseSpeed = 4f;
    public float patrolSpeed = 2f;

    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = patrolSpeed;

        if (waypoints.Length > 0)
            agent.SetDestination(waypoints[currentIndex].position);

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null && CanSeePlayer())
        {
            isChasing = true;
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);
        }
        else if (isChasing)
        {
            isChasing = false;
            agent.speed = patrolSpeed;
            if (waypoints.Length > 0)
                agent.SetDestination(waypoints[currentIndex].position);
        }

        if (!isChasing && !agent.pathPending && agent.remainingDistance < 0.2f)
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentIndex].position);
        }

        if (animator != null)
        {
            bool isWalking = agent.velocity.magnitude > 0.1f;
            animator.SetBool("isWalking", isWalking);
        }
    }

    bool CanSeePlayer()
{
    // Horizontal (flat) direction to player
    Vector3 flatEnemyForward = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
    Vector3 flatDirectionToPlayer = new Vector3(player.position.x - transform.position.x, 0f, player.position.z - transform.position.z).normalized;

    float angle = Vector3.Angle(flatEnemyForward, flatDirectionToPlayer);

    // Full 3D direction for raycasting
    Vector3 directionToPlayer = (player.position + Vector3.up) - (transform.position + Vector3.up);

    if (directionToPlayer.magnitude < viewDistance && angle < viewAngle / 2f)
    {
        Ray ray = new Ray(transform.position + Vector3.up, directionToPlayer.normalized);
        if (Physics.Raycast(ray, out RaycastHit hit, viewDistance))
        {
            if (hit.collider.CompareTag("Player"))
                return true;
        }
    }

    return false;
}


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            // TODO: trigger actual game over logic here
        }
    }
}
