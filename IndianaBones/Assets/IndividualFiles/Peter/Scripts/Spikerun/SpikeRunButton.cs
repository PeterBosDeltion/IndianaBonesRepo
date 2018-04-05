using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRunButton : TriggerdObjects {
	// Use this for initialization
	void Start () {
        puzzleManager = FindObjectOfType<PuzzleManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        puzzleManager.puzzleInsert(this);
    }
}
