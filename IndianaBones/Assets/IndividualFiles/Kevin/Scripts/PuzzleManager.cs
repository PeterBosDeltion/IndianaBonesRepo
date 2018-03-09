using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {

	public List<TriggerdObjects> puzzleTriggerObjects = new List<TriggerdObjects>();
	public List<Puzzle> puzzleList = new List<Puzzle>();
	public int triggers;
	public int puzzle;

	void Start()
	{
		SaveTrigger.finishedPuzzlesSave = new bool[puzzleList.Count];
		if(GameManager.gm.currentData != null)
		{
			foreach(Puzzle currentPuzzle in puzzleList)
			{
				//asing bools uit list in current data
			}
		}
	}
	//checked de puzzle list en probeert uit een functie een bool bvalue te krijgen die confirmed als je de puzzle af hebt
	public void puzzleInsert(TriggerdObjects currentObject)
	{
		bool done = false;
		done = puzzleList[currentObject.puzzleNumber].PuzzleTrigger(currentObject);

		if(done == true)
		{
			print("Trigger check");
			if(triggers == 0)
			{
				print("puzzle done");
				puzzleTriggerObjects[currentObject.puzzleNumber].TriggerFunctionality();
				puzzleList[currentObject.puzzleNumber].puzzleDone = true;
				SaveTrigger.finishedPuzzlesSave.SetValue(true,currentObject.puzzleNumber);
			}
		}
	}
}
