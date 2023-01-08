using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionVolume : MonoBehaviour
{
    public CutieMirrorBehaviour cutieBehaviour;

    public float gaugeSpeed;

    private void OnTriggerStay(Collider other)
    {
        cutieBehaviour.LaunchGauge(gaugeSpeed);
    }

    private void OnTriggerExit(Collider other)
    {
        cutieBehaviour.StopGauge();
    }
}
