using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class VRTransitionLogic : MonoBehaviour {

    [SerializeField]
    private HeadsetToggle world;

    [SerializeField]
    private LinearMapping map;

    [SerializeField]
    [Range(0, 1)]
    private float enterVRThreshold;

    private float previousValue;

    private void Start()
    {
        map.value = 0;
    }

    private void Update()
    {
        if (map.value != previousValue)
        {
            CheckValue();
        }
        previousValue = map.value;
    }

    public void CheckValue()
    {
        if (map.value < enterVRThreshold)
        {
           world.SwitchPerspectiveTo(HeadsetToggle.PERSPECTIVES.RL);
        }
        else if (map.value == 1)
        {
            world.SwitchPerspectiveTo(HeadsetToggle.PERSPECTIVES.VR);
        }
    }
}
