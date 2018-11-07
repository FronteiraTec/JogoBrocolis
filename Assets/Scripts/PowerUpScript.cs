using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;

namespace JogoBrocolis.FTec {
  public class PowerUpScript : MonoBehaviour {

    HUDScript hud;
    AudioSource test;

    void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player") {

        //very ineficient
        hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
        hud.IncreaseScore(10);

        test = GameObject.Find("SomCoin").GetComponent<AudioSource>();
        test.Play();
        Destroy(this.gameObject);
      }
    }
  }
}
