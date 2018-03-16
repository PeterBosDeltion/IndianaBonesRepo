using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMoveButton : TriggerdObjects {
    public GameObject arrowToTrigger;
    public bool moveRight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        arrowToTrigger.GetComponent<SelecterArrow>().Trigger(moveRight);
    }
}
