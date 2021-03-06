﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody rb;
    public Animator anim;
    public float speed;

    public bool jump;
    

    //public float jumpCooldown;
    public float x;

    public float jumpHeight = 7;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jump = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}
    
    void Update()
    {
        Jump();
    }
 

    void Move()
    {
        if (GetComponent<PlayerMovement>().isActiveAndEnabled)
        {
            x = Input.GetAxis("Horizontal");
            transform.Translate(transform.right * -x * speed * Time.deltaTime);
        }


        if (x < 0)
        {
            transform.localScale = new Vector3(-0.8F, 0.8F, 0.8F);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if(x == 0)
        {
            //Do nothing plz dont delete kevin
        }
        else
        {
            transform.localScale = new Vector3(0.8F, 0.8F, 0.8F);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
      
        if(x != 0)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);

        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);
        }
    }

    void Jump()
    {
        Vector3 pos = new Vector3(transform.position.x,transform.position.y + 0.1f,transform.position.z);
        if (Physics.Raycast(pos += new Vector3(-0.2f,0,0),Vector3.down,0.1f) || Physics.Raycast(pos += new Vector3(0.27f,0,0),Vector3.down,0.1f))
        {
            Debug.DrawRay(pos += new Vector3(0.27f,0,0),Vector3.down);
            Debug.DrawRay(pos += new Vector3(-0.2f,0,0),Vector3.down);
            anim.SetBool("Jump", false);
            if(Input.GetButtonDown("Jump"))
            {
                if(rb != null)
                {
                    rb.velocity += new Vector3(0, jumpHeight, 0);
                    anim.SetBool("Jump", true);
                    anim.SetBool("Run", false);
                    anim.SetBool("Idle", false);
                }
                else
                {
                    Debug.LogError("Variable rb (RigidBody) is null, Script: PlayerMovement");
                }
            }
        }
        else
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
            anim.SetBool("Idle", false);
        }
    }
}
