﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public PuzzleManager puzzleManager;
	public List<TriggerdObjects> toTrigger = new List<TriggerdObjects>();
    public bool pressurePlate;
	public GameObject shadedObject;
	//refrence naar type in player script
	public int interactionType;

	public bool triggersPuzzlePart;

	public new ParticleSystem particleSystem;
	public static bool interacting;
	void Start()
	{
		puzzleManager = FindObjectOfType<PuzzleManager>();
	}
	public void Trigger()
	{	
		foreach(TriggerdObjects trigger in toTrigger)
		{
            if(trigger != null)
            {
                trigger.TriggerFunctionality();
            }
        }
	}

	public void OnTriggerStay(Collider other)
	{
		if(other.transform.gameObject.tag == "Player")
		{
			print("collisison check");
			if(interacting == false)
			{
                if (other.GetComponent<Animator>().GetBool("Idle") == true)
                {
                    if (Input.GetButtonDown("E"))
                    {
                        if (interactionType == 1)
                        {
							particleSystem.Emit(1);
                        }
                        interacting = true;
                        Player.Interact(interactionType);
                        StartCoroutine(FindObjectOfType<Player>().RestartMovement());
                        if (triggersPuzzlePart)
                        {
                            puzzleManager.triggers = toTrigger.Count;
                        }
                        Trigger();
                    }
                }
			}
		}
	}
    public void OnTriggerEnter(Collider other)
    {
        if (pressurePlate && other.transform.tag == "Player")
        {
            Trigger();
        }
	    if(other.transform.gameObject.tag == "Player")
		{
			if(shadedObject != null)
			{
				if(shadedObject.GetComponent<TriggerdObjects>().outlineMat != null)
				{
					shadedObject.GetComponent<TriggerdObjects>().OutlineShaderToggle();
				}
			}
		}
	}
	public void OnTriggerExit(Collider other)
	{
		if(other.transform.gameObject.tag == "Player")
		{
			if(shadedObject != null && shadedObject.GetComponent<TriggerdObjects>().outlineMat != null)
			{
				shadedObject.GetComponent<TriggerdObjects>().OutlineShaderToggle();
			}
		}	
	}

}
