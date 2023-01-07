using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regard : MonoBehaviour
{
   
    //Raycast
    RaycastHit hit;


    // Couche ou le screamer est
    [SerializeField]
    LayerMask Screamer;

    [SerializeField]
    GameObject screamer; 
    
    public bool isActivate;

    public Vector3 dir;

    public float timerView;


    //Death Screen
    public bool gameOver = false;
    public GameObject deathScreen;
    
    void Start()
    {
        Screamer = LayerMask.GetMask("screamer");
        screamer = GameObject.FindWithTag("Player");
        deathScreen.SetActive(false);
     

       
    }

    // Update is called once per frame
    void Update()
    {

        dir = screamer.transform.position;
        // Affiche le raycast en temps réel
        Debug.DrawRay(transform.position,dir* 10,Color.red);

        if(isActivate)
        StartCoroutine(watchingYou());
        //If animation se retourner is playing : StartCoroutine(Fade());

        

        if(Physics.Raycast(transform.position,transform.forward, out hit,50, Screamer))
        {
            gameOver = true;
            deathScreen.SetActive(true);

        } 
    }


    // définir un range avec fae
    IEnumerator watchingYou()
    {
        if(Physics.Raycast(transform.position,dir, out hit,50, Screamer))
        {
            timerView +=1;
            if(timerView >5)
            {
            gameOver = true;
            deathScreen.SetActive(true);
            yield return null;
            }
            
        } else 
        
        {
             timerView -=1;
             
             
        }
    }

    


    


   
}
