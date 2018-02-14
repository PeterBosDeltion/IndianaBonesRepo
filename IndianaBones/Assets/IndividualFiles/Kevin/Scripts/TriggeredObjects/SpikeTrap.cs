using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : TriggerdObjects {

	public override void TriggerFunctionality()
	{
		transform.position = new Vector3(0,transform.position.y + 0.2f,0);
	}
}
