using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	int score = 0;
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");

		GUI.Label (new Rect (Screen.width / 2 - 40, 300, 80, 30), "Score: " + score);
		if(GUI.Button(new Rect(Screen.width / 2 - 150, 350, 300, 30), "Tentar de novo? Pressionar Espaço") || Input.GetKeyDown("space"))
		{
			Application.LoadLevel(0);
		}
	}
}
