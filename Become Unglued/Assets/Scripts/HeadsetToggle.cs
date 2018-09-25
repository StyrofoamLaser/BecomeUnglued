using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class HeadsetToggle : MonoBehaviour {

    [SerializeField]
    private Transform rigRL;

    [SerializeField]
    private Transform rigVR;

    [SerializeField]
    private Hand handVR;

    enum PERSPECTIVES
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
            rigVR.gameObject.SetActive(true);
            rigRL.gameObject.SetActive(false);
        }
        else
        {
            currentPerspective = PERSPECTIVES.RL;
            rigRL.gameObject.SetActive(true);
            rigVR.gameObject.SetActive(false);
        }
    }
}
