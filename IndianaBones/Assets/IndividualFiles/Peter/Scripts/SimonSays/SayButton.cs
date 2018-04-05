using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayButton : TriggerdObjects {
    private bool lightingUp;
    public SimonSaysPuzzle simonSaysPuzzle;

    public GameObject obj;
	// Use this for initialization
	void Start () {
        puzzleManager = FindObjectOfType<PuzzleManager>();
        //foreach (Transform t in transform)
        //{
        //    if (t.name == "Cylinder003")
        //    {
        //        obj = t.gameObject;
        //    }
        //}

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator LightUp(float time)
    {
        if (!lightingUp)
        {
            lightingUp = true;

            obj.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            GetComponentInChildren<InteractableObject>().enabled = false;
            yield return new WaitForSeconds(time);
            GetComponentInChildren<InteractableObject>().enabled = true;
            obj.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

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
