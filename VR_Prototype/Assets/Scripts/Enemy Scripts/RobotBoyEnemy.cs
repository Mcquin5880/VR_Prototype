using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HutongGames.PlayMaker;

public class RobotBoyEnemy : MonoBehaviour
{
    [SerializeField] GameObject transportParent;
    [SerializeField] float chaseRadius = 8f;

    float distanceToTarget = Mathf.Infinity;
    Transform playerPosition;
    Vector3 startingPosition;

    NavMeshAgent navMeshAgent;

    // for current RB implementation, all enemies are sent back to original destination as soon as a single one catches the player
    private bool chasingPlayer = true;
    private bool caughtPlayer = false;

    public void SetChasingPlayer(bool value)
    {
        this.chasingPlayer = value;
    }

    public void SetCaughtPlayer(bool  value)
    {
        this.caughtPlayer = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerPosition = FindObjectOfType<Player>().transform;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (chasingPlayer)
        {
            ChaseAndCatchPlayer();
        }
        else if (caughtPlayer)
        {
            navMeshAgent.SetDestination(startingPosition);
            if (Vector2.Distance(this.transform.position, startingPosition) <= .2)
            {
                Debug.Log(gameObject.name + " made it back to original destination");
                RobotBoyTransportUp();
            }
        }   
        
    }

    void ChaseAndCatchPlayer()
    {
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(playerPosition.position);

        distanceToTarget = Vector3.Distance(this.transform.position, playerPosition.position);
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            SendAllRobotBoysBackToSpawnPosition();
        }
    }

    
    void RobotBoyTransportUp()
    {
        GetComponent<Animator>().SetTrigger("backToIdle");
        transportParent.GetComponent<PlayMakerFSM>().SendEvent("testingEvent");
    }

    public void SendAllRobotBoysBackToSpawnPosition()
    {
        RobotBoyEnemy[] rbArray = FindObjectsOfType<RobotBoyEnemy>();
        Debug.Log("Made it here, bot count: " + rbArray.Length);

        foreach (RobotBoyEnemy rb in rbArray)
        {
            rb.SetChasingPlayer(false);
            rb.SetCaughtPlayer(true);
            // for future reference, tried different methods for setting the stopping distance to 0 for all robot boys in scene
            // and this is the only method that would work
            rb.navMeshAgent.stoppingDistance = 0;
        }
    }
    
}
