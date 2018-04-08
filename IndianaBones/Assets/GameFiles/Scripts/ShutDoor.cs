using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDoor : InteractableObject {

	//Asign de deur die dicht moet gaan in de inspector en zet de deur op triggerd en roteer de deur 110 gradezen in Z - als het links is
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
