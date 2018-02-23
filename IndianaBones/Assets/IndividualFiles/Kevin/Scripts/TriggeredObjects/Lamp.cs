using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : TriggerdObjects {
    public ParticleSystem fire;
    
    void Start()
    {
        puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
        fire = GetComponentInChildren<ParticleSystem>();
    }

	public override void TriggerFunctionality()
	{
        print("step 1");
        if(puzzleManager.puzzleList[puzzleNumber].returnBool == false)
        {
              print("step 2");
            if (!fire.isPlaying)
            {
                fire.Play();
            }
            else
            {
                fire.Stop();
            }
            puzzleManager.puzzleInsert(this);
        }
    }
}
