using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationlockPuzzle : Puzzle {
    public CombinationLockWheel myWheel;
    private bool canCycle = true;
    public float cycleCooldown = 2;

    public int i;

    public List<TriggerdObjects> trapsLose = new List<TriggerdObjects>();
	// Use this for initialization
	void Start () {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    // Update is called once per frame
    void Update () {
        CycleWheel();
	}

    public override void PuzzleTrigger(TriggerdObjects currentObject)
    {
        if(myWheel.currentSelected == myWheel.combination[i])
        {
            Debug.Log("Correct");
            i++;

            if(i == myWheel.combination.Count)
            {
                puzzleManager.done = true;
            }
        }
        else
        {
            Debug.Log("Incorrect");
            i = 0;
            //Trigger traps
            foreach (TriggerdObjects t in trapsLose)
            {
                t.TriggerFunctionality();
            }
        }
    }

    public void CycleWheel()
    {
        if (canCycle)
        {
            StartCoroutine(StartCycle());
        }
    }

    private IEnumerator StartCycle()
    {
        canCycle = false;
        myWheel.TriggerFunctionality();
        yield return new WaitForSeconds(cycleCooldown);
        canCycle = true;
    }
}
