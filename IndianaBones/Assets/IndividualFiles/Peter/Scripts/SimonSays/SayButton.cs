using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayButton : TriggerdObjects {
    private bool lightingUp;
    public SimonSaysPuzzle simonSaysPuzzle;
	// Use this for initialization
	void Start () {
        puzzleManager = FindObjectOfType<PuzzleManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator LightUp(int time)
    {
        if (!lightingUp)
        {
            lightingUp = true;
            GetComponent<InteractableObject>().enabled = false;
            Vector3 spos = transform.position;
            transform.position = new Vector3(spos.x, spos.y + .5F, spos.z);
            yield return new WaitForSeconds(time);
            transform.position = spos;
            GetComponent<InteractableObject>().enabled = true;
            lightingUp = false;

        }


    }

    public override void TriggerFunctionality()
    {
        TriggerPuzzleManager();
        Debug.Log("Pressed " + transform.name);
        //if(simonSaysPuzzle.insertedOrder.Count < simonSaysPuzzle.correctOrder.Count)
        //{
        //    simonSaysPuzzle.EnterButton(gameObject);
        //}
    }

    public void TriggerPuzzleManager()
    {
        puzzleManager.puzzleInsert(this);
    }
}
