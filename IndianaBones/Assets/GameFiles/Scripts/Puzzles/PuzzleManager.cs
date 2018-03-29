using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {

	public List<TriggerdObjects> puzzleTriggerObjects = new List<TriggerdObjects>();
	public List<Puzzle> puzzleList = new List<Puzzle>();
	public int triggers;
	public int puzzle;

	public bool done;
	void Start()
	{
		SaveTrigger.finishedPuzzlesSave = new bool[puzzleList.Count];
		if(GameManager.gm != null)
		{
			if(GameManager.gm.currentData != null)
			{
				foreach(bool currentBool in GameManager.gm.currentData.finishedPuzzles)
				{
					puzzleList[puzzle].puzzleDone = currentBool;
					if(currentBool == true)
					{
						puzzleTriggerObjects[puzzle].TriggerFunctionality();
					}
					puzzle += 1;
				}
			}
		}
		else
		{
			Debug.LogError("Variable GameManager.gm = null, try launching from menu, Script: PuzzleManager");
		}
	}
	//checked de puzzle list activeerd de bijhoorende puzzle functie en returned uitijndelijk een bool zonder de restrictie die de function een bool maken geeft
	public void puzzleInsert(TriggerdObjects currentObject)
	{
		done = false;
		puzzleList[currentObject.puzzleNumber].PuzzleTrigger(currentObject);
		print(done);
		if(done == true)
		{
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
