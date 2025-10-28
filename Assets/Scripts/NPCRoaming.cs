using UnityEngine;
using UnityEngine.AI;

public class NPCRoaming : MonoBehaviour
{
    public NavMeshAgent characterMoving;
    public Transform[] walkingPoints;
    public float distanceDestinies;
    private int destinies;
    public float idleTimer;
    public float walkingSpeed = 5.5f;
    public float idleTime = 2.0f;
    public float detection;
    public Transform playerInRange;
    private DialogueManager playerTalking;

    public enum NPC_STATE
    {
        Idle,
        Walking,
        Talking
    }
    public NPC_STATE currentState;

    void Start()
    {
        currentState = NPC_STATE.Idle;
        distanceDestinies = Vector3.Distance(transform.position, walkingPoints[destinies].position);
        characterMoving.destination = walkingPoints[destinies].position;
        playerInRange = FindAnyObjectByType<Player>().transform;
    }

    public void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, playerInRange.position);
        switch (currentState)
        {
            case NPC_STATE.Idle:
                idleTimer -= Time.deltaTime;
                if (idleTimer <= 0)
                {
                    destinies = (destinies + 1) % walkingPoints.Length;
                    WalkingState();
                }
                break;

            case NPC_STATE.Walking:
                if (!characterMoving.pathPending && characterMoving.remainingDistance < 0.5f)
                {
                    IdleState();
                }
                break;

           /* case NPC_STATE.Talking:
                if (playerDistance <= detection && )
                {
                    IdleState();
                }*/
        }
    }
    void IdleState()
    {
        currentState = NPC_STATE.Idle;
        idleTimer = idleTime;
        characterMoving.isStopped = true;
    }
    void WalkingState()
    {
        currentState = NPC_STATE.Walking;
        characterMoving.isStopped = false;
        characterMoving.speed = walkingSpeed;
        characterMoving.destination = walkingPoints[destinies].position;
    }
}
