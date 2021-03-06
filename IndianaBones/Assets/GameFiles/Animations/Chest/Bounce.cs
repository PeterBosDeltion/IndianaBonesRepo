﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : TriggerdObjects
{
	private Rigidbody rb;

	//private Vector3 startpos;

	public float forceAmount;
	public float randomSideForce;
	public bool moveZ;

    public float jumpHeight;

	private void Awake()
	{
		player = FindObjectOfType<Player>();
		rb = GetComponent<Rigidbody>();
		//startpos = transform.position;
	}

	void Update()
	{
		if(moveZ == true)
		{
			Vector3 targetPosition = new Vector3(transform.position.x,transform.position.y,player.transform.position.z); 
			transform.position = Vector3.Lerp(transform.position,targetPosition,3 * Time.deltaTime);
		}
	}
    public override void TriggerFunctionality()
    {
        PushUp();
    }

    public void PushUp()
	{
		// De Vector3 die straks gerandomized gaat worden.
		Vector3 randomizer;

		// Random getal ( nul of één ), als hij nul is schiet hem naar links, als hij één is schiet hem naar rechts.
		int leftOrRight = Random.Range(0, 2);
		if (leftOrRight == 0)
		{
			// Random force naar links.
			randomizer = new Vector3(Random.Range(randomSideForce, 2 * randomSideForce), 0, 0);
		}
		else
		{
			// Random force naar rechts.
			randomizer = new Vector3(Random.Range(-randomSideForce, -(2 * randomSideForce)), 0, 0);
		}

		// Add de force om hem omhoog te schieten
		rb.AddForce((Vector3.up + randomizer) * forceAmount, ForceMode.Impulse);
		moveZ = true;
	}
}
