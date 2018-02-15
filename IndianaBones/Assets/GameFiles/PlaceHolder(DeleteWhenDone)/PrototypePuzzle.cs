using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypePuzzle : TriggerdObjects {
    public List<GameObject> lights = new List<GameObject>();
    private int correctAmount;
    public Door objectToTrigger;
    public List<TriggerdObjects> trapsToTrigger = new List<TriggerdObjects>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        foreach (GameObject g in lights)
        {
            if(g.GetComponent<Renderer>().material.color == Color.yellow)
            {
                correctAmount++;
            }
            else
            {
                correctAmount = 0;
                foreach (TriggerdObjects t in trapsToTrigger)
                {
                    t.TriggerFunctionality();
                }
                break;
            }
        }

        if(correctAmount == lights.Count)
        {
            objectToTrigger.TriggerFunctionality();
        }
    }
}
