using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportCube : MonoBehaviour
{
    public void PlayMechanicalAudio()
    {
        GetComponent<AudioSource>().Play();
    }
   
}
