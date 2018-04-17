using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : TriggerdObjects {
	
	public bool puzzle;
	public Material button;
	public Material buttonBase;
	public bool keepGoingAfterFinished;

    private bool emissionOff;
    public GameObject redCircle;
	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
        foreach (Transform t in transform)
        {
            if(t.transform.name == "Cylinder003")
            {
                redCircle = t.gameObject;
            }
        }
	}
	public override void TriggerFunctionality()
	{
        if (!emissionOff)
        {
            StartCoroutine(ChangeEmissive());
        }
		GetComponent<Animator>().SetTrigger("Push");
		if(puzzle == true)
		{
			
			 if(!puzzleManager.puzzleList[puzzleNumber].puzzleDone)
        	{
           		puzzleManager.puzzleInsert(this);
        	}
            else if(keepGoingAfterFinished && (puzzleManager.puzzleList[puzzleNumber].puzzleDone))
            {
                puzzleManager.puzzleInsert(this);
            }
        }
	}

    IEnumerator ChangeEmissive()
    {
        emissionOff = true;
        foreach (Material m in redCircle.GetComponent<Renderer>().materials)
        {
            redCircle.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
        yield return new WaitForSeconds(.5F);
        foreach (Material m in redCircle.GetComponent<Renderer>().materials)
        {
            redCircle.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        emissionOff = false;
    }
}
