using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedJumpPuzzle : Puzzle {

	public List<TriggerdObjects> beams = new List<TriggerdObjects>();
	public float time;
	public float timeBetween;

	void Start()
	{
		puzzleManager = FindObjectOfType<PuzzleManager>();
	}
	public override void PuzzleTrigger(TriggerdObjects currentObject)
	{
		if(currentObject.puzzlePart == 0)
		{
			foreach(TriggerdObjects beam in beams)
			{
				StartCoroutine(NextBeam(beam));
				time += timeBetween;
			}
		}
		if(currentObject.puzzlePart == 1)
		{
			puzzleManager.done = true;
		}
		
	}

	public IEnumerator NextBeam(TriggerdObjects beam)
	{
		yield return new WaitForSeconds(time);
		beam.TriggerFunctionality();
	}
}
