using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCorrectSequence : TriggerdObjects {
    public SimonSaysPuzzle simonSaysPuzzle;
    public bool displayCorrect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
  
            simonSaysPuzzle.StartCoroutine(simonSaysPuzzle.ShowOrder());
       
    }
}
