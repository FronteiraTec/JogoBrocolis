using UnityEngine;
using System.Collections;


namespace JogoBrocolis.FTec {
  public class SpawnScriptCar : MonoBehaviour {

    AudioSource soundCar;

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

      StartCoroutine("waitTimeSoundCar");
    }

    private IEnumerator waitTimeSoundCar() {
      yield return new WaitForSeconds(1);

      var somRandom = Random.Range(0, 2);
      if (somRandom == 0) {
        soundCar = GameObject.Find("CarPassing").GetComponent<AudioSource>();
      } else {
        soundCar = GameObject.Find("CarPassing2").GetComponent<AudioSource>();
      }

      soundCar.Play();
    }
  }
}
