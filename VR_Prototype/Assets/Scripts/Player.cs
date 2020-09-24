using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DarkTonic.MasterAudio;

public class Player : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    [SerializeField] GameObject playerLaserPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float projectileSpeed = 100f;
    [SerializeField] float timeBetweenShots = .5f;

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
    /*
    bool canShoot = false;

    // test
    bool weaponsActive = false;
    
    public void Shoot()
    {
        if (canShoot == true)
        {
            firingCoroutine = StartCoroutine(FirePlayerLaser());
        }
    }
    
    IEnumerator FirePlayerLaser()
    {
        while (true)
        {
            canShoot = false;
            GameObject laser = Instantiate(playerLaserPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
            laser.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * projectileSpeed;
            MasterAudio.PlaySound3DAtTransform("PlayerLaser", spawnPoint);

            yield return new WaitForSeconds(timeBetweenShots);
            canShoot = true;
        }
    }
    

    
    public void ActivateWeapon()
    {
        if (weaponsActive == false)
        {
            print("made it here.");
            weaponsActive = true;
            ActivateLasers();
        }
        else if (weaponsActive == true)
        {
            weaponsActive = false;
            DeactivateLasers();
        }
    }

    public void StopFiringLaser()
    {
        StopCoroutine(FirePlayerLaser());
        canShoot = true;
    }

    private void ActivateLasers()
    {
        canShoot = true;
    }

    private void DeactivateLasers()
    {
        canShoot = false;      
    }
    */




}
