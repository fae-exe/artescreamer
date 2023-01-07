using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regard : MonoBehaviour
{
   

    RaycastHit hit;

    // Couche ou le screamer est
    [SerializeField]
    LayerMask Screamer;

    public bool gameOver = false;
    public GameObject deathScreen;
    
    void Start()
    {
        Screamer = LayerMask.GetMask("screamer");
         deathScreen.SetActive(false);

       
    }

    // Update is called once per frame
    void Update()
    {

        // Affiche le raycast en temps réel
        Debug.DrawRay(transform.position,transform.forward* 10,Color.red);
        if(Physics.Raycast(transform.position,transform.forward, out hit,50, Screamer))
        {
            gameOver = true;
            deathScreen.SetActive(true);

        } 
    }


   
}
