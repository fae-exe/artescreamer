using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomNumberScript : MonoBehaviour
{
    public int roomNumber;
    public CutieMirrorBehaviour cutieBehaviour;

    public void OnTriggerEnter(Collider other)
    {
        cutieBehaviour.roomNumber = roomNumber;
    }
}
