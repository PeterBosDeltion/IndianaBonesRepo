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
	}
	public override void OutlineShaderToggle()
	{
		if(triggerd != true)
		{
			print("functie");
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
	public override void TriggerFunctionality()
	{
		GetComponent<Animator>().SetBool("Return",returnLever);
		GetComponent<Animator>().SetTrigger("Pull");
		if(returnLever != true)
		{
			OutlineShaderToggle();
			triggerd = true;
		}
		if(puzzle == true)
		{
			puzzleManager.puzzleInsert(this);
		}
	}
}
