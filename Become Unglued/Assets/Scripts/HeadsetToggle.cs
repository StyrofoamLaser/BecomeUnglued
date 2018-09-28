using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class HeadsetToggle : MonoBehaviour {

    [SerializeField]
    private Hand handVR;

    [SerializeField]
    private Camera camRL;

    [SerializeField]
    private Camera camVR;

    public enum PERSPECTIVES
    {
        RL,
        VR
    };

    [SerializeField]
    public PERSPECTIVES currentPerspective;

    [SerializeField]
    private List<GameObject> vrObjs;

    [SerializeField]
    private List<GameObject> rlObjs;

    public void EnterVR()
    {
        SwitchPerspectiveTo(PERSPECTIVES.VR);
    }

    public void SwitchPerspectiveTo(PERSPECTIVES p)
    {
        currentPerspective = p;

        if (currentPerspective == PERSPECTIVES.RL)
        {
            camRL.GetComponentInChildren<AudioListener>().enabled = true;
            camVR.enabled = false;
            camVR.GetComponentInChildren<AudioListener>().enabled = false;

            ToggleObjects(rlObjs, true);
            ToggleObjects(vrObjs, false);
        }
        else
        {
            camRL.GetComponentInChildren<AudioListener>().enabled = false;
            camVR.enabled = true;
            camVR.GetComponentInChildren<AudioListener>().enabled = true;

            ToggleObjects(rlObjs, false);
            ToggleObjects(vrObjs, true);
        }
    }

    public void ToggleObjects(List<GameObject> listToToggle, bool enabled)
    {
        foreach (GameObject g in listToToggle)
        {
            g.SetActive(enabled);
        }
    }

    public void AddRLObj(GameObject g)
    {
        rlObjs.Add(g);
    }

    public void AddVRObj(GameObject g)
    {
        vrObjs.Add(g);
    }

    public void RemoveRLObj(GameObject g)
    {
        rlObjs.Remove(g);
    }

    public void RemoveVRObj(GameObject g)
    {
        vrObjs.Remove(g);
    }
}
