using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationlockPuzzle : Puzzle {
    public CombinationLockWheel myWheel;
    private bool canCycle = true;
    public float cycleCooldown = 2;

    public int i;
    public GameObject correctLight;
    public float blinkCorrectTime = 1.5F;
    private bool blinking;

    public List<TriggerdObjects> trapsLose = new List<TriggerdObjects>();
    // Use this for initialization
    void Start() {
        puzzleManager = FindObjectOfType<PuzzleManager>();
        foreach (Transform t in myWheel.transform)
        {
            if (t.name == "CorrectLight")
            {
                correctLight = t.gameObject;
                correctLight.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }
        }
    }

    // Update is called once per frame
    void Update() {
        CycleWheel();
    }

    public override void PuzzleTrigger(TriggerdObjects currentObject)
    {
        if (myWheel.currentSelected == myWheel.combination[i])
        {

            StartCoroutine(BlinkLight(blinkCorrectTime));

            Debug.Log("Correct");
            i++;


            if (i == myWheel.combination.Count)
            {
                puzzleManager.done = true;
                StartCoroutine(BlinkCorrect());
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

    private IEnumerator BlinkCorrect()
    {
        yield return new WaitForSeconds(blinkCorrectTime);
        StartCoroutine(BlinkLight(4));
    }

    private IEnumerator BlinkLight(float f)
    {
        if (!blinking)
        {
            blinking = true;
            correctLight.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(f);
            correctLight.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            blinking = false;
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
