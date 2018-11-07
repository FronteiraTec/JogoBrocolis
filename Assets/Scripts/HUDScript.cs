using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;

namespace JogoBrocolis.FTec {
  public class HUDScript : MonoBehaviour {

    float playerScore = 0;
    bool playerChomping;
    bool playerBritadeirando;
    PlatformerCharacter2D player;

    void awake() {

    }
    void Update() {
      playerScore += Time.deltaTime;
      player = GameObject.Find("CharacterRobotBoy").GetComponent<PlatformerCharacter2D>();
      setChompingHud(player.getChomping());
      setBritadeirandoHud(player.getBritadeirando());

    }

    public void IncreaseScore(int amount) {
      playerScore += amount;
    }

    void OnDisable() {
      //when gets disable save on player preferences, but not a great place to save
      //would be better to a pack with a score to persist and say "dont destroy on load"
      PlayerPrefs.SetInt("Score", (int)playerScore);
    }

    public void setChompingHud(bool chomp) {
      playerChomping = chomp;
    }

    public void setBritadeirandoHud(bool brita) {
      playerBritadeirando = brita;
    }

    void OnGUI() {
      GUI.Label(new Rect(10, 40, 150, 50), "Britadeirando: " + playerBritadeirando);
      GUI.Label(new Rect(10, 25, 100, 50), "Chomping: " + playerChomping);
      GUI.Label(new Rect(10, 10, 100, 50), "Score: " + (int)(playerScore));
    }
  }
}
