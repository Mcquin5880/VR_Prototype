using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootTest : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float projectileSpeed = 50f;

    // testing
    bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireRepeatedly());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FireRepeatedly()
    {
        while (canShoot)
        {
            GameObject laser = Instantiate(laserPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
            laser.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * projectileSpeed;
            canShoot = false;
            yield return new WaitForSeconds(2f);
            canShoot = true;
        }       
    }
}
