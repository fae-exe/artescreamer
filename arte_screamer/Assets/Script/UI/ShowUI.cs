using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
   public GameObject uiObject;
   public Animator anim;
   public string nomTrigger;
    
    void Start()
    {
       
        Debug.Log(nomTrigger);
        uiObject.SetActive(false);
      
       // Debug.Log(anim);
        
     }

    void OnTriggerEnter(Collider player) {
        if(player.gameObject.tag == "Player") {
             uiObject.SetActive(true);
            anim.SetTrigger(nomTrigger);
            StartCoroutine("Waitforsec");
        }
    }

    IEnumerator Waitforsec() {
        yield return new WaitForSeconds(5);
        
    }
}
