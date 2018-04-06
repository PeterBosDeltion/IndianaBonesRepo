using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDoor : InteractableObject {

	public bool closed;
	public void OnTriggerEnter()
	{
		if(closed == false)
		{
			closed = true;
			Trigger();
		}
	}
}
