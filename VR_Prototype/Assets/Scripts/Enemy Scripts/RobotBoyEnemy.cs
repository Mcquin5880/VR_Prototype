using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotBoyEnemy : MonoBehaviour
{
    [SerializeField] float chaseRadius = 5f;
    [SerializeField] float rotationSpeed = 5f;

    private float distanceToTarget = Mathf.Infinity;

    // temp set to true for testing
    bool enemyIsAggroed = false;

    NavMeshAgent navMeshAgent;
    EnemyHealth health;
    CapsuleCollider capsuleCollider;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            capsuleCollider.enabled = false;
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (enemyIsAggroed)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRadius)
        {
            enemyIsAggroed = true;
        }
    }

    public void OnDamageTaken()
    {
        enemyIsAggroed = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        if (!health.IsDead())
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
