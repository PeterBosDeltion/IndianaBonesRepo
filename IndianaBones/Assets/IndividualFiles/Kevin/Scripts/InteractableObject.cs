using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public PuzzleManager puzzleManager;
	public List<TriggerdObjects> toTrigger = new List<TriggerdObjects>();

	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
	}
	public void Trigger()
	{	
		foreach(TriggerdObjects trigger in toTrigger)
		{
			trigger.TriggerFunctionality();
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if(other.transform.gameObject.tag == "Player")
		{
			print("collisison check");
			if(Input.GetButtonDown("E"))
			{
				print("Pressed");
				puzzleManager.triggers = toTrigger.Count;
				Trigger();
			}
		}
	}
}
