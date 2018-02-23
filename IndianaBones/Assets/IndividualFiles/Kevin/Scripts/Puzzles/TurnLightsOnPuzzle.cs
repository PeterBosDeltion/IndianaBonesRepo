using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightsOnPuzzle : Puzzle {

	public List<bool> torches = new List<bool>();
	
	public override bool PuzzleTrigger(int trigger)
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
		return returnBool;
	}
}
