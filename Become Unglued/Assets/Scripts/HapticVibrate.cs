using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticVibrate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void VibrateController(int index, int duration)
    {
        SteamVR_Controller.Input(0).TriggerHapticPulse((ushort)duration);
        Debug.Log("vibrating");
    }
}
