using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class HeadsetToggle : MonoBehaviour {

    [SerializeField]
    private Transform rigRL;

    [SerializeField]
    private Transform rigVR;

    enum PERSPECTIVES
    {
        RL,
        VR
    };

    [SerializeField]
    private PERSPECTIVES currentPerspective;

    private Hand hand;

    // Use this for initialization
    void Start () {
        hand = GetComponent<Hand>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hand == null || hand.controller == null)
        {
            return;
        }

        if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            var axis = hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

            if (axis.y <= -0.5f)
            {
                SwitchPerspective();
            }
        }
	}

    void SwitchPerspective()
    {
        if (currentPerspective == PERSPECTIVES.RL)
        {
            rigVR.gameObject.SetActive(true);
            rigRL.gameObject.SetActive(false);
        }
        else
        {
            rigRL.gameObject.SetActive(true);
            rigVR.gameObject.SetActive(false);
        }
    }
}
