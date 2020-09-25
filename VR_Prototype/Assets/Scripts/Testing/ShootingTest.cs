using DarkTonic.MasterAudio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTest : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float projectileSpeed = 100f;
    [SerializeField] float timeBetweenShots = .25f;
    [SerializeField] GameObject playerLaserPrefab;

    Coroutine firingCoroutine;
    bool canShoot = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FirePlayerLaser());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopAllCoroutines();
        }
        
    }

    IEnumerator FirePlayerLaser()
    {
        while (true)
        {
            Debug.Log("Hey there");

            GameObject laser = Instantiate(playerLaserPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
            laser.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * projectileSpeed;
            MasterAudio.PlaySound3DAtTransform("PlayerLaser", spawnPoint);

            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
