using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitVROnTrigger : MonoBehaviour {

    [SerializeField]
    private Collider trigger;

    [SerializeField]
    private HeadsetToggle persp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (other == trigger)
        {
            persp.SwitchPerspectiveTo(HeadsetToggle.PERSPECTIVES.RL);
        }
    }

    private void moo(Collision collision)
    {
        Debug.Log("collision");
        if (collision.collider == trigger)
        {
            persp.SwitchPerspectiveTo(HeadsetToggle.PERSPECTIVES.RL);
        }
    }

}
