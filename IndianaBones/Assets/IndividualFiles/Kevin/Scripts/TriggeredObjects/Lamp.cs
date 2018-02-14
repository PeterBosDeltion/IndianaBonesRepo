using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : TriggerdObjects {

	public override void TriggerFunctionality()
	{
		//GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

        if (GetComponent<Renderer>().material.color != Color.yellow)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }

    }
}
