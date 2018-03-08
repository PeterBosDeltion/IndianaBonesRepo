using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public PuzzleManager puzzleManager;
	public List<TriggerdObjects> toTrigger = new List<TriggerdObjects>();
    public bool pressurePlate;

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
				//puzzleManager.triggers = toTrigger.Count; Doe dit alleen als je ook daadwerkelijk een puzzel doet pls k thx
				Trigger();
			}
		}
	}

    public void OnTriggerEnter(Collider other)
    {
        if (pressurePlate) //Ik denk niet dat je op E moet drukken als je over een pressure plate loopt
        {
            Trigger();
        }
    }
}
