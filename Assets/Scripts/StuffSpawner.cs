using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour
{
    public GameObject[] stuff;
    public Transform generationPoint;

    public float stuffWidth;

    private void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + stuffWidth, transform.position.y, transform.position.z);

            Instantiate(stuff[Random.Range(0, stuff.GetLength(0))], transform.position, transform.rotation);
        }
    }
}
