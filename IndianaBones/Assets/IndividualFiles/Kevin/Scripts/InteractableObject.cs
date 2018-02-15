using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public List<TriggerdObjects> toTrigger = new List<TriggerdObjects>();

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
			if(Input.GetButtonDown("E"))
			{
				Trigger();
			}
		}
	}
}
