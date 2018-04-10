using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rb;
    public Animator anim;
    public float speed;

    public bool jump;
    

    public float jumpForce;
    public float jumpCooldown;
    public float x;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jump = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
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
                    rb.AddRelativeForce(transform.up * jumpForce * Time.deltaTime);
                    anim.SetBool("Jump", true);
                }
                else
                {
                    Debug.LogError("Variable rb (RigidBody) is null, Script: PlayerMovement");
                }
            }
        }
    }
}
