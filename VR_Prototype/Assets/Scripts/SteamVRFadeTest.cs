using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVRFadeTest : MonoBehaviour
{
    private float _fadeDuration = 1f;

    private void Start()
    {
        FadeToWhite();
        Invoke("FadeFromWhite", .1f);
    }
    private void FadeToWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, 3f);
    }
    private void FadeFromWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, 5);
    }

}
