using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLockWheel : TriggerdObjects {
    public int currentSelected = -1;

    public List<int> combination = new List<int>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        Cycle();
    }

    public void Cycle()
    {
        if(currentSelected < 9)
        {
            currentSelected++;
            GetComponent<ObjectDescriptor>().descriptions.Clear();
            GetComponent<ObjectDescriptor>().descriptions.Add("" + currentSelected);
        }
        else if(currentSelected == 9)
        {
            currentSelected = 0;
            GetComponent<ObjectDescriptor>().descriptions.Clear();
            GetComponent<ObjectDescriptor>().descriptions.Add("" + currentSelected);
        }
    }
}
