using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class PowerUpChompObstacleScript : MonoBehaviour
{

    HUDScript hud;
    AudioSource test;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
            var player = GameObject.Find("CharacterRobotBoy").GetComponent<PlatformerCharacter2D>();
            var chomping = player.getChomping();

            if (chomping)
            {
                hud.IncreaseScore(50);
                Destroy(this.gameObject);
            } else
            {
                Application.LoadLevel(1);
                return;
            }

        }
    }
}
