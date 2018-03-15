using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : TriggerdObjects {

	public override void TriggerFunctionality()
	{
		GetComponent<Animator>().SetTrigger("Pull");
	}
}
