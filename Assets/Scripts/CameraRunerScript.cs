using UnityEngine;
using System.Collections;

namespace JogoBrocolis.FTec {
  public class CameraRunerScript : MonoBehaviour {

    public Transform player;

    //offsets

    // Update is called once per frame
    void Update() {
      transform.position = new Vector3(player.position.x + 6f, 0f, -22f);
    }
  }
}
