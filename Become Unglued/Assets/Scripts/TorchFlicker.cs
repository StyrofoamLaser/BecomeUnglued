using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlicker : MonoBehaviour {

    [SerializeField]
    [Range(0, 2)]
    private float intensityMin;

    [SerializeField]
    [Range(0, 2)]
    private float intensityMax;

    private Light light;

    private float intensityDefault;

    [SerializeField]
    private float timeSinceFlicker = 0;

    [SerializeField]
    private float timeTillNextFlicker = 0;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        intensityDefault = light.range;
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceFlicker += Time.deltaTime;

        if (timeSinceFlicker >= timeTillNextFlicker)
        {
            light.intensity = Random.Range(intensityMin, intensityMax);
            timeSinceFlicker = 0;
            timeTillNextFlicker = Random.Range(0, Random.Range(0.01f, 0.05f));
        }
	}
}
