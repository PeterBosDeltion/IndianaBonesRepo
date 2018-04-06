using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyrimPuzzle : Puzzle 
{
	public List<bool> finishedParts = new List<bool>();

	void Start()
	{
		puzzleManager = FindObjectOfType<PuzzleManager>();
	}
	public override void PuzzleTrigger(TriggerdObjects currentObject)
	{
		if(currentObject.puzzlePart == 3)
		{
			PuzzleCheck();
		}
	}

	public void PuzzleCheck()
	{
		returnBool = true;
		foreach (bool b in finishedParts)
		{
			if(b == false)
			{
				returnBool = false;
			}
		}
		puzzleManager.done = returnBool;
	}
}
