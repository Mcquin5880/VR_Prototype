using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSphere : MonoBehaviour
{

    AudioSource audioSource;
    [SerializeField] AudioClip sphereOpenAudio, chargingUpAudio, dashAudio;
    Animator anim;
    RobotSphere_Child_AnimDriver robotSphereChild;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        robotSphereChild = GetComponentInChildren<RobotSphere_Child_AnimDriver>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayImpactAudio()
    {
        audioSource.Play();
    }

    public void PlayOpenSphereAudio()
    {
        audioSource.PlayOneShot(sphereOpenAudio);
    }

    public void PlayChargingUpAudio()
    {
        audioSource.PlayOneShot(chargingUpAudio);
    }

    public void PlayDashAudio()
    {
        audioSource.PlayOneShot(dashAudio);
    }

    // -----------------------------------------------------------------------------------------------

    public void PlayRobotSphereOpenAnimation()
    {
        robotSphereChild.SetOpenAnimation();
    }

    public void PlayCloseIntoRollAnimation()
    {
        robotSphereChild.SetCloseIntoRollAnimation();
    }

    public void PlayImpactAnimation()
    {
        robotSphereChild.SetImpactStopSpinAnimation();
    }
}
