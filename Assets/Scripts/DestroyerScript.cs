using UnityEngine;
using System.Collections;

namespace JogoBrocolis.FTec {
  public class DestroyerScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player") {
        //freezes the game
        //Debug.Break ();
        Restarter.CallGameOver();
        return;
      }

      if(other.gameObject.transform.parent) {
        Destroy(other.gameObject.transform.parent.gameObject);
      } else {
        Destroy(other.gameObject);
      }
    }
  }
}
