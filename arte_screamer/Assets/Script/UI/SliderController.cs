using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
  
   int progress = 0;
   
   
   public Text valueText;
   public Slider slider;

   public GameObject endLine;


   public void OnSliderChanged(float value){
    valueText.text= value.ToString();

   }
   public void UpdateProgress(){

    progress++;
    slider.value = progress;

   }
}
