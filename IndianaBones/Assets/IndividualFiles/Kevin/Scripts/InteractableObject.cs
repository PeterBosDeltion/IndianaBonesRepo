using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public PuzzleManager puzzleManager;
	public List<TriggerdObjects> toTrigger = new List<TriggerdObjects>();
    public bool pressurePlate;

	public bool triggersPuzzlePart;

	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
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
			if(Input.GetButtonDown("E"))
			{
				print("Pressed");
				if(triggersPuzzlePart)
				{
					puzzleManager.triggers = toTrigger.Count;
				}
				Trigger();
			}
		}
	}

    public void OnTriggerEnter(Collider other)
    {
        if (pressurePlate && other.transform.tag == "Player")
        {
            Trigger();
        }
    }
}
