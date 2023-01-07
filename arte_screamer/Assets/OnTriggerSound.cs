using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSound : MonoBehaviour
{

    AudioSource m_MyAudioSource;

    void Start()
    {
         m_MyAudioSource = GetComponent<AudioSource>();

     }
    
    private void OnTriggerEnter(Collider other) 
    {
           
            if (other.tag == "Player") 
            //Play the audio you attach to the AudioSource component
            m_MyAudioSource.Play();
            Debug.Log("collide");
        
        
    }

     private void OnTriggerExit(Collider other) 
    {
            
            if (other.tag == "Player") 
            //Stop the audio
            m_MyAudioSource.Stop();
         
        
    }
}
