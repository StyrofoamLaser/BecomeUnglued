using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour {

    [SerializeField]
    private float minIntensity;

    [SerializeField]
    private float maxIntensity;

    [SerializeField]
    private float cycleSpeed = 1;

    bool increasing = true;

    private Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        light.intensity = minIntensity;
	}
	
	// Update is called once per frame
	void Update () {
		if (increasing)
        {
            light.intensity = Mathf.Lerp(light.intensity, maxIntensity, Time.deltaTime * cycleSpeed);
            if (light.intensity >= (maxIntensity * .85f))
            {
                increasing = false;
            }
        }
        else
        {
            light.intensity = Mathf.Lerp(light.intensity, minIntensity, Time.deltaTime * cycleSpeed);
            if (light.intensity <= (minIntensity * 1.15f))
            {
                increasing = true;
            }
        }
	}
}
