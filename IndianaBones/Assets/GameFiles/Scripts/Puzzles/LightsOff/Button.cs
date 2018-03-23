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

			//naam shit werkt niet
			else if(mats[1].name == "ButtonBase")
			{
				print("3");
				mats[1] = buttonBase;
				partsLeft += 1;
				if(partsLeft == 2)
				{
					outline = false;
				}
			}
			else if(mats[1].name == "Button")
			{
				print("4");
				mats[1] = button;
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
