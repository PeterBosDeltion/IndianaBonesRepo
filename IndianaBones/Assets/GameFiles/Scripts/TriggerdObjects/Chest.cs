using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : TriggerdObjects {

	public override void TriggerFunctionality()
	{
		GetComponent<Animator>().SetTrigger("Open");
	}
}
