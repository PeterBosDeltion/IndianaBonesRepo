using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRun : Puzzle {

    public List<TriggerdObjects> spikes = new List<TriggerdObjects>();
    public float spikeInterval = 2;
	// Use this for initialization
	void Start () {
        puzzleManager = FindObjectOfType<PuzzleManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void PuzzleTrigger(TriggerdObjects currentObject)
    {
        puzzleManager.done = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartPuzzle();
        }
    }

    public void StartPuzzle()
    {
        StartCoroutine(DeploySpikes());
    }

    IEnumerator DeploySpikes()
    {
        foreach (TriggerdObjects t in spikes)
        {
            yield return new WaitForSeconds(spikeInterval);

            t.TriggerFunctionality();
        }
    }
}
