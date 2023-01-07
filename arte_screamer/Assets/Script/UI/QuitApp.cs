using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
  public void doExitGame() {
    Application.Quit();
    Debug.Log("application fermé");
  }
}
