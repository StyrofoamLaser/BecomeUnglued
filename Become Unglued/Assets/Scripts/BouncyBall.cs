using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour {

    [SerializeField]
    private int maxBounces = 10;

    [SerializeField]
    private int numBounces = 0;

    public void AddBounce()
    {
        numBounces++;

        if (numBounces >= maxBounces)
        {
            DestroyMe();
        }
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        AddBounce();
        GetComponent<AudioSource>().Play();
    }
}
