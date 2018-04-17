using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedJumpPuzzle : Puzzle {

	public List<TriggerdObjects> beams = new List<TriggerdObjects>();
	private float time;
	public float timeBetween;
	private int beamsLeft;

	void Start()
	{
		puzzleManager = FindObjectOfType<PuzzleManager>();
	}
	public override void PuzzleTrigger(TriggerdObjects currentObject)
	{
		if(beamsLeft == 0)
		{
			if(currentObject.puzzlePart == 0)
			{
				beamsLeft = beams.Count;
				foreach(TriggerdObjects beam in beams)
				{
					StartCoroutine(NextBeam(beam));
					time += timeBetween;
				}
			}
			else if(currentObject.puzzlePart == 1)
			{
				puzzleManager.done = true;
			}
		}
		
	}

	public IEnumerator NextBeam(TriggerdObjects beam)
	{
		yield return new WaitForSeconds(time);
		beam.TriggerFunctionality();
		beamsLeft -= 1;
		if(beamsLeft == 0)
		{
			time = 0;
		}
	}
}
