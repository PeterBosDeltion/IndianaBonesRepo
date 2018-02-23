using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {

	public List<TriggerdObjects> puzzleTriggerObjects = new List<TriggerdObjects>();
	public List<Puzzle> puzzleList = new List<Puzzle>();

	//checked de puzzle list en probeert uit een functie een bool bvalue te krijgen die confirmed als je de puzzle af hebt
	public void puzzleInsert(TriggerdObjects currentObject)
	{
		bool done = false;
		done = puzzleList[currentObject.puzzleNumber].PuzzleTrigger(currentObject.puzzlePart);
		if(done == true)
		{
			print("puzzle done");
			puzzleTriggerObjects[currentObject.puzzleNumber].TriggerFunctionality();
		}
	}
}
