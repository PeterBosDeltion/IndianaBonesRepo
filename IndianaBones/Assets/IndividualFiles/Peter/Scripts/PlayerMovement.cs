using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rb;
    public Animator anim;
    public float speed;
    //public float stamina;
    //public float staminaUseRate;

    //public int sprintCooldown;
    //public float sprintSpeed;

    //public float startSpeed;
    //public bool canSprint;
    

    public float jumpForce;
    public float jumpCooldown;
    public float x;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //startSpeed = speed;
        //canSprint = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        //Sprint();
        Jump();
	}

    void Move()
    {
        x = Input.GetAxis("Horizontal");

        transform.Translate(transform.right * -x * speed * Time.deltaTime);

        if(x < 0)
        {
            transform.localScale = new Vector3(-0.8F, 0.8F, 0.8F);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if(x == 0)
        {

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

    //void Sprint() //Need to fix this
    //{
    //    if (Input.GetButton("Shift"))
    //    {
    //        if (stamina > 0 && canSprint)
    //        {
    //            stamina -= staminaUseRate;
    //            speed += sprintSpeed;
    //        }
    //        else if (stamina <= 0 && canSprint)
    //        {

    //            if (speed != startSpeed)
    //            {
    //                speed = startSpeed;
    //            }
    //            canSprint = false;
    //            StartCoroutine(SprintCooldown());
    //        }
    //    }
    //    else
    //    {
    //        if(speed != startSpeed)
    //        {
    //            speed = startSpeed;
    //        }
    //        if(stamina < 100)
    //        {
    //            stamina += staminaUseRate * Time.deltaTime;
    //        }
    //    }
    //}

    //public IEnumerator SprintCooldown()
    //{
    //    yield return new WaitForSeconds(sprintCooldown);
    //    canSprint = true;

    //}

    void Jump()
    {
        Vector3 pos = new Vector3(transform.position.x,transform.position.y + 0.1f,transform.position.z);
        RaycastHit hit;
        if (Physics.Raycast(pos,Vector3.down,out hit,0.1f))
        {
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
