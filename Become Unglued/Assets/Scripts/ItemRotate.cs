using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour {

    [SerializeField]
    [Range(0, 359)]
    private float rate = 2.0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), rate * Time.deltaTime);
	}
}
