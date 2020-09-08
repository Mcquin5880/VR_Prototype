using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVRFade : MonoBehaviour
{
    [SerializeField] float fadeDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        FadeInCamera();
    }

    private void FadeInCamera()
    {
        SteamVR_Fade.Start(Color.black, 0f);
        SteamVR_Fade.Start(Color.clear, 5);
    }
}
