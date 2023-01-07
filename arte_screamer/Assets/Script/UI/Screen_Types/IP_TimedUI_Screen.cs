using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class IP_TimedUI_Screen : IP_UI_Screen
{
    #region Variables
    [Header("Timed Screen Properties")]
    public float m_ScreenTime = 2f;
    public UnityEvent OnTimeCompleted = new UnityEvent();
    
    
    
    private float startTime;

    #endregion

    #region Helper Methods
    public override void StartScreen ()
    {
        base.StartScreen();

        startTime = Time.time;
        StartCoroutine(WaitForTime());

    }
    IEnumerator WaitForTime ()
    {
        yield return new WaitForSeconds(m_ScreenTime);
        if(OnTimeCompleted !=null) 
        {
         OnTimeCompleted.Invoke();
        }
    }
    
    #endregion
}
