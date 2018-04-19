using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : TriggerdObjects {

	void Start () 
	{
		partsLeft = 2;
	}
	
	public override void TriggerFunctionality()
	{
		OutlineShaderToggle();
	}
}
