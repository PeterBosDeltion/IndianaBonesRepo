using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : TriggerdObjects {
	
	public bool puzzle;
	public Material button;
	public Material buttonBase;
	bool outline = false;
	int partsLeft = 2;
	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
	}
	public override void TriggerFunctionality()
	{
		//GetComponent<Animator>().SetTrigger("Push");
		if(puzzle == true)
		{
			if(puzzleManager.puzzleList[puzzleNumber].puzzleDone == false)
        	{
           		puzzleManager.puzzleInsert(this);
        	}
		}
	}

	public override void OutlineShaderToggle()
	{
		foreach (GameObject child in outlineChilds)
		{
			print("1");
			mats = child.GetComponent<Renderer>().materials;
			print(outline);
			if(mats[1] != outlineMat && outline != true)
			{
				print("2");
				mats[1] = outlineMat;
				partsLeft -= 1;
				if(partsLeft == 0)
				{
					outline = true;
				}
			}
			
			else
			{
				print("3");
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
