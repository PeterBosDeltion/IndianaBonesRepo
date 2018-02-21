using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public float stamina;
    public float staminaUseRate;

    public int sprintCooldown;
    public float sprintSpeed;
    public float jumpForce;

    private float startSpeed;
    private bool canSprint;

    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        startSpeed = speed;
        canSprint = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        Sprint();
	}

    void Move()
    {
        float x = Input.GetAxis("Horizontal");

        transform.Translate(transform.right * x * speed * Time.deltaTime);
    }

    void Sprint()
    {
        if (Input.GetButton("Shift"))
        {
            if (stamina > 0 && canSprint)
            {
                stamina -= staminaUseRate;
                speed += sprintSpeed;
            }
            else if (stamina <= 0 && canSprint)
            {

                if (speed != startSpeed)
                {
                    speed = startSpeed;
                }
                canSprint = false;
                StartCoroutine(SprintCooldown());
            }
        }
        else
        {
            if(speed != startSpeed)
            {
                speed = startSpeed;
            }
            if(stamina < 100)
            {
                stamina += staminaUseRate / 8;
            }
        }
    }

    public IEnumerator SprintCooldown()
    {
        yield return new WaitForSeconds(sprintCooldown);
        canSprint = true;

    }
}
