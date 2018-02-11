using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public TriggerdObjects toTrigger;
	public int puzzleNumber;

	public void Trigger()
	{
		toTrigger.TriggerFunctionality();
	}

	public void OnCollisionStay(Collision collision)
	{
		if(collision.transform.tag == "Player")
		{
			if(Input.GetButtonDown("E"))
			{
				Trigger();
			}
		}
	}
}
