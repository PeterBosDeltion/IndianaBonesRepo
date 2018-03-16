using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveTrigger : TriggerdObjects {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        gameObject.SetActive(false);
    }
}
