using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : TriggerdObjects {

	public override void TriggerFunctionality()
	{
		GetComponent<Animator>().SetTrigger("Trigger");
	}

}
