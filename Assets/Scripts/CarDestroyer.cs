using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;

namespace JogoBrocolis.FTec {
  public class CarDestroyer : MonoBehaviour {

    public GameObject ironExplosion;

    void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player") {
        var player = GameObject.Find("BrocolisPlayer").GetComponent<PlatformerCharacter2D>();
        var chomping = player.getChomping();
        var britadeirando = player.getBritadeirando();

        if(chomping && britadeirando) {
          print("card eaten");
          GameObject.Find("Main Camera").GetComponent<HUDScript>().IncreaseScore(100);
          GameObject.Find("Crash").GetComponent<AudioSource>().Play();
          Instantiate(ironExplosion, transform.position, Quaternion.identity);
          Destroy(this.gameObject);
        } else {
          Restarter.CallGameOver();
          return;
        }
      }
    }
  }
}
