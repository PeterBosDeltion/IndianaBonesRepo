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
		partsLeft = outlineChilds.Count;
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
