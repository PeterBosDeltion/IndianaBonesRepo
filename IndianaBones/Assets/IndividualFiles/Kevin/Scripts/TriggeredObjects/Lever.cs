using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : TriggerdObjects {

	public bool puzzle;
 	public bool returnLever;
	public Material lever;
	public Material leverBase;
	bool outline = false;
	int partsLeft = 2;

	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
		mats[1] = lever;
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
			else if(mats[1].name == "Feet")
			{
				print("3");
				mats[1] = leverBase;
				partsLeft += 1;
				if(partsLeft == 2)
				{
					outline = false;
				}
			}
			else if(mats[1].name == "Handel")
			{
				print("4");
				mats[1] = lever;
				partsLeft += 1;
				if(partsLeft == 2)
				{
					outline = false;
				}
			}
			child.GetComponent<Renderer>().materials = mats;
		}
	}
	public override void TriggerFunctionality()
	{
		GetComponent<Animator>().SetBool("Return",returnLever);
		GetComponent<Animator>().SetTrigger("Pull");
		if(returnLever != true)
		{
			triggerd = true;
			OutlineShaderToggle();
		}
		if(puzzle == true)
		{
			puzzleManager.puzzleInsert(this);
		}
	}
}
