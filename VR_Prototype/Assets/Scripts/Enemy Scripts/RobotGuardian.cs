using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;

public class RobotGuardian : MonoBehaviour
{

    [SerializeField] float hitpoints = 100;
    [SerializeField] Material deathMaterial;
    [SerializeField] GameObject deathExplosion1;
    [SerializeField] GameObject deathExplosion2;
    [SerializeField] Transform mainSpawnPoint;


    public void TakeDamage(float damage)
    {
        hitpoints = Mathf.Max(0, hitpoints - damage);
        if (hitpoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(DeathSequence());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DamageDealer")
        {          
            TakeDamage(20f);
        }
    }

    IEnumerator DeathSequence()
    {
        GetComponentInChildren<MeshRenderer>().material = deathMaterial;
        GetComponent<Animator>().SetTrigger("DeathSequence");
        GetComponent<SphereCollider>().enabled = false;
        deathExplosion1.SetActive(true);
        MasterAudio.PlaySound3DAtTransform("Enemy_Death_Explosion1", mainSpawnPoint);

        StartCoroutine(SecondDeathExplosion());

        yield return new WaitForSeconds(1.8f);
        Destroy(gameObject);
    }

    IEnumerator SecondDeathExplosion()
    {
        yield return new WaitForSeconds(1.35f);
        deathExplosion2.SetActive(true);
        MasterAudio.PlaySound3DAtTransform("Enemy_Death_Explosion2", mainSpawnPoint);
    }
}
