using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HutongGames.PlayMaker;

public class RobotBoyEnemy : MonoBehaviour
{
    [SerializeField] float chaseRadius = 8f;

    float distanceToTarget = Mathf.Infinity;
    Transform playerPosition;
    Vector3 startingPosition;

    NavMeshAgent navMeshAgent;


    // testing
    bool chasingPlayer = true;
    bool caughtPlayer = false;

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
            ChasePlayer();
        }
        else if (caughtPlayer)
        {
            navMeshAgent.SetDestination(startingPosition);
            if (Vector2.Distance(this.transform.position, startingPosition) <= .2)
            {
                Debug.Log("MADE IT");
                BotTransportUpTest();
                PlayMakerFSM.BroadcastEvent("testingEvent");
            }
        }
        
        distanceToTarget = Vector3.Distance(this.transform.position, playerPosition.position);
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            chasingPlayer = false;
            caughtPlayer = true;
            // stopping distance needs to be set to 0 because it won't go all the way to its starting destination
            navMeshAgent.stoppingDistance = 0;
        }
        
        
    }

    void ChasePlayer()
    {
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(playerPosition.position);
    }

    
    void BotTransportUpTest()
    {
        GetComponent<Animator>().SetTrigger("backToIdle");
    }
    
}
