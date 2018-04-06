using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPillar : TriggerdObjects {

	public enum Side
	{
		side1,
		side2,
		side3
	}
	public Side side;
	public int correctState;
	void Start()
	{
		puzzleManager = FindObjectOfType<PuzzleManager>();
		GetComponent<Animator>().SetInteger("CurentState", (int)side);
	}
	public override void TriggerFunctionality()
	{
		puzzleManager.triggers += 1;
		if(side == Side.side1)
		{
			side = Side.side2;
			GetComponent<Animator>().SetTrigger("Rotate");
			if(correctState == 2)
			{
				puzzleManager.puzzleInsert(this);
			}
			else
			{
				puzzleManager.triggers -= 1;
			}
		}
		else if(side == Side.side2)
		{
			side = Side.side3;
			GetComponent<Animator>().SetTrigger("Rotate");
			if(correctState == 3)
			{
				print("ya boi");
				puzzleManager.puzzleInsert(this);
			}
			else
			{
				puzzleManager.triggers -= 1;
			}
		}
		else if(side == Side.side3)
		{
			side = Side.side1;
			GetComponent<Animator>().SetTrigger("Rotate");
			if(correctState == 1)
			{
				puzzleManager.puzzleInsert(this);
			}
			else
			{
				puzzleManager.triggers -= 1;
			}
		}
	}
}
