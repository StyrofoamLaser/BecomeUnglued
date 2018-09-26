using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class HeadsetToggle : MonoBehaviour {

    [SerializeField]
    private Camera rlCam;

    [SerializeField]
    private Camera vrCam;

    [SerializeField]
    private Hand handVR;

    public enum PERSPECTIVES
    {
        RL,
        VR
    };

    [SerializeField]
    private PERSPECTIVES currentPerspective;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (handVR == null || handVR.controller == null || currentPerspective == PERSPECTIVES.RL)
        {
            return;
        }
        
        if (handVR.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            var axis = handVR.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

            if (axis.y <= -0.5f)
            {
                SwitchPerspective();
            }
        }
	}

    public void SwitchPerspective()
    {
        Debug.Log("switching persp");
        if (currentPerspective == PERSPECTIVES.RL)
        {
            currentPerspective = PERSPECTIVES.VR;
        }
        else
        {
            currentPerspective = PERSPECTIVES.RL;
        }
    }

    public void SwitchPerspectiveTo(PERSPECTIVES p)
    {
        currentPerspective = p;

        if (currentPerspective == PERSPECTIVES.RL)
        {
            rlCam.enabled = true;
            vrCam.enabled = false;
        }
        else
        {
            rlCam.enabled = false;
            vrCam.enabled = true;
        }
    }
}
