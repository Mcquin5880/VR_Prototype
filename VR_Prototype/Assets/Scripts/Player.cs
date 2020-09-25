using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DarkTonic.MasterAudio;

public class Player : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    [SerializeField] GameObject playerLaserPrefab;
    [SerializeField] float projectileSpeed = 100f;
    [SerializeField] float timeBetweenShots = .25f;
    [SerializeField] Transform rightHandSpawnPoint;

    Coroutine firingCoroutine;

    private int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        
    }

    public void HandlePlayerDeath()
    {
        FadeToBlack();
        MasterAudio.PlaySound("Death_Alarm");
        MasterAudio.PlaySound("Death_Alarm");

        StartCoroutine(WaitAndRestartCurrentLevel());
    }

    private void FadeToBlack()
    {
        SteamVR_Fade.Start(Color.clear, 0f);
        SteamVR_Fade.Start(Color.black, 1f);
    }

    IEnumerator WaitAndRestartCurrentLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneIndex);
    }

    // Player laser / weapons properties -------------------------------------------------------------------------------------------------------------

    bool canShoot = true;

    
    public void Shoot()
    {
        if (canShoot == true)
        {
            firingCoroutine = StartCoroutine(FirePlayerLasers());
        }
    }
    
    IEnumerator FirePlayerLasers()
    {
        while (true)
        {

            GameObject laser = Instantiate(playerLaserPrefab, rightHandSpawnPoint.position, rightHandSpawnPoint.rotation) as GameObject;
            laser.GetComponent<Rigidbody>().velocity = rightHandSpawnPoint.transform.forward * projectileSpeed;
            MasterAudio.PlaySound3DAtTransform("PlayerLaser", rightHandSpawnPoint);

            yield return new WaitForSeconds(timeBetweenShots);
 
        }
    }

    public void StopFiringLasers()
    {
        StopAllCoroutines();
    }
    




}
