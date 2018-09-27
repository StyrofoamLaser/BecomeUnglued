using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class MegaBuster : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform bulletSpawn;

    private Hand hand;

    private bool canFire = true;

    public float firePower = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnAttachedToHand(Hand attachedHand)
    {
        hand = attachedHand;
    }

    private void HandAttachedUpdate(Hand hand)
    {
        if (hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (canFire)
            {
                Shoot();
                canFire = false;
            }
            Debug.Log("Pressed trigger on megabuster");
        }
        if (hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            canFire = true;
        }

        if (hand.controller.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            hand.DetachObject(this.gameObject);
        }
    }

    private void Shoot()
    {
        SpawnBullet();
        GetComponent<AudioSource>().Play();
    }

    private void SpawnBullet()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        bullet.transform.SetPositionAndRotation(bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * firePower, ForceMode.Impulse);
    }
}
