using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    void Move()
    {
        float x = Input.GetAxis("Horizontal");

        transform.Translate(transform.right * x * speed * Time.deltaTime);

    }
}
