using UnityEngine;
using System.Collections;
using JogoBrocolis.FTec;
using UnityEngine.UI;

namespace JogoBrocolis.FTec {

  public class GameOverScript : MonoBehaviour {

    int score = 0;
    int highestScore = 0;
    public Text highestScoreText;
    public Text newHighScoreText;
    public Text scoreText;

    void Start() {
      score = PlayerPrefs.GetInt("Score");
      if (PlayerPrefs.HasKey("HighestScore")) {
        highestScore = PlayerPrefs.GetInt("HighestScore");
      } else {
        SetHighestScore(score);
      }

      if (score > highestScore) {
        SetHighestScore(score);
      } else {
        newHighScoreText.text = "";
      }
    }
    
    private void SetHighestScore (int value) {
      PlayerPrefs.SetInt("HighestScore", value);
      newHighScoreText.text = "WOOO!!!!NEW HIGH SCORE!!!!";
    } 

    void OnGUI() {
      //GUI.Label(new Rect(Screen.width / 2 - 40, 300, 80, 30), "Score: " + score);
      //GUI.Label(new Rect(Screen.width / 2 - 40, 200, 80, 40), "Mais alto: " + highestScore);
      //GUI.Label(new Rect(Screen.width / 2 - 40, 250, 80, 40), "Mais alto: " + higherThanOldScore);
      highestScoreText.text = "Highest Score: " + highestScore;
      scoreText.text = "Score: " + score;
    }

    public void RestartLevel() {
      Restarter.RestartLevel();
    }

    public void BackToMenu() {
      Restarter.RestartLevel();
    }

  }
}
