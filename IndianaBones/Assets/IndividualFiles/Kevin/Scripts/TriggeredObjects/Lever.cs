using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : TriggerdObjects {

	public bool puzzle;
 	public bool returnLever;
	public Material lever;
	public Material leverBase;

	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
		mats[1] = lever;
	}
	public override void OutlineShaderToggle()
	{
		foreach (GameObject child in outlineChilds)
		{
			bool outline = false;
			print("1");
			mats = child.GetComponent<Renderer>().materials;
			if(mats[1] != outlineMat && outline != true)
			{
				print(mats[1]);
				print("2");
				mats[1] = outlineMat;
				outline = true;
			}
			else if(mats[1].name == "feet")
			{
				print("3");
				mats[1] = leverBase;
			}
			else if(mats[1].name == "Handel")
			{
				print("4");
				mats[1] = lever;
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
