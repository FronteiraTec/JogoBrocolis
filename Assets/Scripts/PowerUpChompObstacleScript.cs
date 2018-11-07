using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;

namespace JogoBrocolis.FTec {
  public class PowerUpChompObstacleScript : MonoBehaviour {

    HUDScript hud;

    void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player") {
        hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
        var player = GameObject.Find("CharacterRobotBoy").GetComponent<PlatformerCharacter2D>();
        var chomping = player.getChomping();
        var britadeirando = player.getBritadeirando();

        if(chomping || britadeirando) {
          hud.IncreaseScore(50);
          Destroy(this.gameObject);
        } else {
          Restarter.CallGameOver();
          return;
        }

      }
    }
  }
}
