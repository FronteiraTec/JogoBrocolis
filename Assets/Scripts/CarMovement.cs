using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    //public float timer = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        Vector2 acceleration = new Vector2();
        acceleration = Vector2.left;
        rb.AddForce(acceleration * 2);
    }
}
