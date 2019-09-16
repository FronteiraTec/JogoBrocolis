using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JogoBrocolis.FTec
{
  public class Restarter : MonoBehaviour
  {
    private static void OnTriggerEnter2D(Collider2D other)
    {
      if (other.tag == "Player")
      {
        RestartLevel();
      }
    }

    public static void RestartLevel() {
      SceneManager.LoadScene(1);
    }
    
    public void CallCredits()
        {
            SceneManager.LoadScene(3);
        }
    public void StartLevel() {
      SceneManager.LoadScene(1);
    }

    public void CallMenu() {
      SceneManager.LoadScene(0);
    }

    public static void CallGameOver() {
      SceneManager.LoadScene(2);
    }
  }
}
