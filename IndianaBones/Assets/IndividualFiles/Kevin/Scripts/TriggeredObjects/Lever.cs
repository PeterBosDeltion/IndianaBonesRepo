using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : TriggerdObjects {

	public bool puzzle;

	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
	}
	public override void TriggerFunctionality()
	{
		GetComponent<Animator>().SetTrigger("Pull");
		if(puzzle == true)
		{
			puzzleManager.puzzleInsert(this);
		}
	}
}
