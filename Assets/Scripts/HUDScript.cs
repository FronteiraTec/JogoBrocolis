using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;
using UnityEngine.UI;

namespace JogoBrocolis.FTec {
  public class HUDScript : MonoBehaviour {

    float playerScore = 0;
    bool playerChomping;
    bool playerBritadeirando;
    public Text scoreTextMainScreen;

    void awake() {

    }
    void Update() {
      playerScore += Time.deltaTime;
      var player = GameObject.Find("BrocolisPlayer").GetComponent<PlatformerCharacter2D>();
      setChompingHud(player.getChomping());
      setBritadeirandoHud(player.getBritadeirando());

    }

    public void IncreaseScore(int amount) {
      playerScore += amount;
    }

    void OnDisable() {
      PlayerPrefs.SetInt("Score", (int)playerScore);
    }

    public void setChompingHud(bool chomp) {
      playerChomping = chomp;
    }

    public void setBritadeirandoHud(bool brita) {
      playerBritadeirando = brita;
    }

    void OnGUI() {
      //GUI.Label(new Rect(10, 40, 150, 50), "Britadeirando: " + playerBritadeirando);
      //GUI.Label(new Rect(10, 25, 100, 50), "Chomping: " + playerChomping);
      //GUI.Label(new Rect(10, 10, 100, 50), "Score: " + (int)(playerScore));
      scoreTextMainScreen.text = "Score: " + (int)(playerScore);
    }
  }
}
