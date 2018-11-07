using UnityEngine;
using System.Collections;

namespace JogoBrocolis.FTec {
  public class InstantDeathBoxScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player") {
        Restarter.CallGameOver();
        return;
      }
    }
  }
}
