using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyrimPuzzle : Puzzle 
{
    //a list of booleans to keep track of which pillar is rotated correctly
	public List<bool> finishedParts = new List<bool>();
    //The object that will trigger to kill the palyer when the outcome is wrong
	public TriggerdObjects trap;

	void Start()
	{
		puzzleManager = FindObjectOfType<PuzzleManager>();
	}

    //Takes a Trigger object checking its puzzle part
	public override void PuzzleTrigger(TriggerdObjects currentObject)
	{
        //If the part is specificly the part that has to trigger a completion check
		if(currentObject.puzzlePart == 3)
		{
			PuzzleCheck();
		}
		else
		{
            //if the part is used to make the correct combination
			if(finishedParts[currentObject.puzzlePart] != true)
			{
				finishedParts[currentObject.puzzlePart] = true;
			}
			else
			{
				finishedParts[currentObject.puzzlePart] = false;
			}
		}
	}

    //checks if puzzle is complete/correct
	public void PuzzleCheck()
	{
		returnBool = true;
		foreach (bool b in finishedParts)
		{
            //if any are incorrect it turns the bool false
			if(b == false)
			{
				returnBool = false;
                break;
			}
		}
        //if the bool is false it triggers the trap otherwhise it send a message to the manager to then trigger a door to open
		if(returnBool == false)
		{
			trap.TriggerFunctionality();
		}
		print(returnBool);
		puzzleManager.done = returnBool;
	}
}
