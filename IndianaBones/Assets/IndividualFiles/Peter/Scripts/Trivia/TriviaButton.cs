using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaButton : TriggerdObjects {
    public bool correct;
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
