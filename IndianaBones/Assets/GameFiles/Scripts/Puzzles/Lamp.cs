using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : TriggerdObjects {
    public bool startOn;
    public ParticleSystem fire;
    
    void Start()
    {
        puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
        fire = GetComponentInChildren<ParticleSystem>();
        if(startOn == false)
        {
            fire.gameObject.SetActive(false);
        }
    	if(puzzleManager.puzzleList[puzzleNumber].puzzleDone == true)
        {
            fire.gameObject.SetActive(true);
        }
    }

	public override void TriggerFunctionality()
	{
        if(puzzleManager.puzzleList[puzzleNumber].puzzleDone == false)
        {
            if (!fire.isPlaying)
            {
                fire.gameObject.SetActive(true);
            }
            else
            {
                fire.gameObject.SetActive(false);
            }
            puzzleManager.puzzleInsert(this);
        }
    }
}
