using UnityEngine;
using System.Collections;


namespace JogoBrocolis.FTec {
  public class SpawnScriptHuman : MonoBehaviour {

    public GameObject[] obj;
    //set to spawn at a min of 1sec and a max of 2sec
    public float spawnMin = 1f;
    public float spawnMax = 2f;
      
    // Use this for initialization
    void Start() {
      Spawn();
    }

    void Spawn() {
      //it will instantiate an object from the vector of objects we assign to ita
      Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
      //and then invoke at a rate of 1 or 2 sec
      Invoke("Spawn", Random.Range(spawnMin, spawnMax));

      var random = Random.Range(0, 2);

      if (random == 0) {
        GameObject.Find("Scream").GetComponent<AudioSource>().Play();
      } else {
        GameObject.Find("Scream2").GetComponent<AudioSource>().Play();
      }
    }

  }
}
