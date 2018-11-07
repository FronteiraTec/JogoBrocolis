using UnityEngine;
using System.Collections;

namespace JogoBrocolis.FTec {
  public class CameraRunerScript : MonoBehaviour {

    public Transform player;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
      transform.position = new Vector3(player.position.x + 6, 0, -10);
    }
  }
}
