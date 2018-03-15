using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : TriggerdObjects {
	
	public override void TriggerFunctionality()
	{
		GetComponent<Animator>().SetTrigger("Push");
	}
}
