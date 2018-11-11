using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;

namespace JogoBrocolis.FTec {
  public class PowerUpBritadeirandoScript : MonoBehaviour {

    HUDScript hud;
    AudioSource test;

    void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player") {

        var player = GameObject.Find("CharacterRobotBoy").GetComponent<PlatformerCharacter2D>();
        player.setBritadeirando();

        test = GameObject.Find("SomCoin").GetComponent<AudioSource>();
        test.Play();
        Destroy(this.gameObject);
      } 
    }
  }
}
