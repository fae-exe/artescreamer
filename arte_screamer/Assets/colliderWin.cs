using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderWin : MonoBehaviour
{
        public GameObject winScreen;

        private void OnTriggerEnter(Collider other) 
        {
            winScreen.SetActive(true);
        }

}
