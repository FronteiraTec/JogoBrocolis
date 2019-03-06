using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;

namespace JogoBrocolis.FTec {
  public class HumanDestroyer : MonoBehaviour {

    public GameObject bloodExplosion;

    void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player") {
        var player = GameObject.Find("BrocolisPlayer").GetComponent<PlatformerCharacter2D>();
        var chomping = player.getChomping();

        if(chomping) {
          GameObject.Find("Main Camera").GetComponent<HUDScript>().IncreaseScore(50);
          GameObject.Find("Gore").GetComponent<AudioSource>().Play();
          Instantiate(bloodExplosion, transform.position, Quaternion.identity);
          Destroy(this.gameObject);
        }
      }
    }
  }
}
