using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ProjectileTarget : MonoBehaviour {

    public UnityEvent onHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "projectile")
        {
            onHit.Invoke();
        }
    }
}
