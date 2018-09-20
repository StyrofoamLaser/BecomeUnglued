using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class TouchpadMovement : MonoBehaviour {

    [SerializeField]
    private Transform vrRig;

    private Valve.VR.EVRButtonId touchpad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    private Hand hand;

    private Vector2 axis = Vector2.zero;

    [SerializeField]
    private float speed;

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

        if (hand.controller.GetTouch(touchpad))
        {
            axis = hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

            if (vrRig != null)
            {
                vrRig.position += (transform.right * axis.x + transform.forward * axis.y) * Time.deltaTime * speed;
                vrRig.position = new Vector3(vrRig.position.x, 0, vrRig.position.z);
            }
        }
		
	}
}
