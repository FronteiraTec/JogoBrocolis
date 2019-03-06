using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;

namespace JogoBrocolis.FTec {
  public class PowerUpBritadeirandoScript : MonoBehaviour {

    public GameObject toxicExplosion;

    void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player") {
        var player = GameObject.Find("BrocolisPlayer").GetComponent<PlatformerCharacter2D>();
        player.setBritadeirando();

        GameObject.Find("Main Camera").GetComponent<HUDScript>().IncreaseScore(25);

        Instantiate(toxicExplosion, transform.position, Quaternion.identity);
        GameObject.Find("PowerUp").GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
      } 
    }
  }
}
