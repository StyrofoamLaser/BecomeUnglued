using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class VibrateOnHover : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 3999)]
        private ushort duration;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnHandHoverBegin(Hand hand)
        {
            hand.controller.TriggerHapticPulse((ushort)duration);
        }
    }
}
