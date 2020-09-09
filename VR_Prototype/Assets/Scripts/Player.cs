﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DarkTonic.MasterAudio;

public class Player : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;

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

}