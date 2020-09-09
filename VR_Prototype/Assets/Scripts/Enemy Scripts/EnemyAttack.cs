using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Player target;
    [SerializeField] float damage = 20f;

    private void Start()
    {
        target = FindObjectOfType<Player>();
    }

    public void OnDamageTaken()
    {
        Debug.Log("Testing broadcast");
    }

    /*
    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        target.TakeDamage(damage);
        Debug.Log("Hit detected");
    }
    */
}
