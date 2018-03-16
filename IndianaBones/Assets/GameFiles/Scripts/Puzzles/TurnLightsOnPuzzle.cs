using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightsOnPuzzle : Puzzle {

	public List<bool> torches = new List<bool>();

	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
	}
	public override bool PuzzleTrigger(TriggerdObjects currentObject)
	{
		return CheckTorches(currentObject.puzzlePart);
	}

	public bool CheckTorches(int trigger)
	{
		returnBool = true;
		if(torches[trigger] ==false)
		{
			torches[trigger] = true;
		}
		else
		{
			torches[trigger] = false;
		}
		foreach (bool torch in torches)
		{
			if(torch == false)
			{
				returnBool = false;
			}
		}
		puzzleManager.triggers -= 1;
		return returnBool;
	}
}
