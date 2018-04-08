using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public PuzzleManager puzzleManager;
	public List<TriggerdObjects> toTrigger = new List<TriggerdObjects>();
    public bool pressurePlate;
	public GameObject shadedObject;

	public bool triggersPuzzlePart;

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
			if(Input.GetButtonDown("E"))
			{
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
		else if(other.transform.gameObject.tag == "Player")
		{
			if(shadedObject.GetComponent<TriggerdObjects>().outlineMat != null)
			{
				shadedObject.GetComponent<TriggerdObjects>().OutlineShaderToggle();
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
