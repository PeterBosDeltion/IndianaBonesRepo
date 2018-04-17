using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {

	public List<TriggerdObjects> puzzleTriggerObjects = new List<TriggerdObjects>();
	public List<Puzzle> puzzleList = new List<Puzzle>();
	public int triggers;

	public bool done;
	//checked de puzzle list activeerd de bijhoorende puzzle functie en returned uitijndelijk een bool zonder de restrictie die de function een bool maken geeft
	public void puzzleInsert(TriggerdObjects currentObject)
	{
		done = false;
		puzzleList[currentObject.puzzleNumber].PuzzleTrigger(currentObject);
		if(done == true)
		{
			if(triggers == 0)
			{
				print("puzzle done");
				puzzleTriggerObjects[currentObject.puzzleNumber].TriggerFunctionality();
				puzzleList[currentObject.puzzleNumber].puzzleDone = true;
			}
		}
	}
}
