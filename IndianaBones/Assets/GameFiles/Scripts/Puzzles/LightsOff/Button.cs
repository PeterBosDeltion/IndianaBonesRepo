using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : TriggerdObjects {
	
	public bool puzzle;
	public Material button;
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
		
	}
}
