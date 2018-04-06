using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : TriggerdObjects {
	
	public bool puzzle;
	public Material button;
	public Material buttonBase;
	bool outline = false;
	int partsLeft = 2;

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
			if(puzzleManager.puzzleList[puzzleNumber].puzzleDone == false)
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

    public override void OutlineShaderToggle()
	{
		foreach (GameObject child in outlineChilds)
		{
			mats = child.GetComponent<Renderer>().materials;
			if(mats[1] != outlineMat && outline != true)
			{
				mats[1] = outlineMat;
				partsLeft -= 1;
				if(partsLeft == 0)
				{
					outline = true;
				}
			}
			
			else
			{
				mats[1] = mats[0];
				partsLeft += 1;
				if(partsLeft == 2)
				{
					outline = false;
				}
			}
			child.GetComponent<Renderer>().materials = mats;
		}
	}
}
