using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSphere_Child_AnimDriver : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOpenAnimation()
    {
        GetComponent<Animator>().SetTrigger("sphere_Open");
    }

    public void SetCloseIntoRollAnimation()
    {
        GetComponent<Animator>().SetTrigger("sphere_Close_Into_Roll");
    }

    public void SetImpactStopSpinAnimation()
    {
        GetComponent<Animator>().SetTrigger("impact_Stop_Spin");
    }
}
