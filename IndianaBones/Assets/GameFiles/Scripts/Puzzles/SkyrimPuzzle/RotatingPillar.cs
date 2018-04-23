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
	private bool canMove = true;

    public AudioSource source;
    public AudioClip stoneTurn;
    private GameManager gm;
	void Start()
	{
        gm = FindObjectOfType<GameManager>();
		partsLeft = 2;

        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        stoneTurn = gm.stoneTurn;
        source.clip = stoneTurn;


		puzzleManager = FindObjectOfType<PuzzleManager>();
		GetComponent<Animator>().SetInteger("CurentState", (int)side);
		GetComponent<Animator>().SetTrigger("Rotate");
		if(correctState == (int)side)
		{
			puzzleManager.puzzleInsert(this);
		}
	}
	public override void TriggerFunctionality()
	{
		if(puzzleManager.puzzleList[puzzleNumber].puzzleDone != true && canMove == true)
		{
            source.Play();

			canMove = false;
			StartCoroutine(rotationBlock());
			if(correctState == (int)side)
			{
				puzzleManager.puzzleInsert(this);
			}
			if(side == Side.side1)
			{
				side = Side.side2;
				GetComponent<Animator>().SetTrigger("Rotate");
				if(correctState == (int)side)
				{
					puzzleManager.puzzleInsert(this);
				}
			}
			else if(side == Side.side2)
			{
				side = Side.side3;
				GetComponent<Animator>().SetTrigger("Rotate");
				if(correctState == (int)side)
				{
					puzzleManager.puzzleInsert(this);
				}
			}
			else if(side == Side.side3)
			{
				side = Side.side1;
				GetComponent<Animator>().SetTrigger("Rotate");
				if(correctState == (int)side)
				{
					puzzleManager.puzzleInsert(this);
				}
			}
		}
	}

	public IEnumerator rotationBlock()
	{
		yield return new WaitForSeconds(1.2f);
		canMove = true;
	}
}
