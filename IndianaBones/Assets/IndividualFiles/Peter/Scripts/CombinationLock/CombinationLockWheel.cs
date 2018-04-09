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
        if(currentSelected < 12)
        {
            currentSelected++;
            //GetComponent<ObjectDescriptor>().descriptions.Clear();
            //GetComponent<ObjectDescriptor>().descriptions.Add("" + currentSelected);
        }
        else if(currentSelected == 12)
        {
            currentSelected = 0;
            //GetComponent<ObjectDescriptor>().descriptions.Clear();
            //GetComponent<ObjectDescriptor>().descriptions.Add("" + currentSelected);
        }

        if(currentSelected == 1)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -15);

        }
        else if (currentSelected == 2)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -45);

        }
        else if (currentSelected == 3)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -75);

        }
        else if (currentSelected == 4)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -105);
            Debug.Log("4");

        }
        else if (currentSelected == 5)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -135);

        }
        else if (currentSelected == 6)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -165);

        }
        else if (currentSelected == 7)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -195);

        }
        else if (currentSelected == 8)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -225);

        }
        else if (currentSelected == 9)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -254);

        }
        else if (currentSelected == 10)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -285);

        }
        else if (currentSelected == 11)
        {
            transform.localRotation = Quaternion.Euler(0, -180, -315);

        }
        else if (currentSelected == 12)
        {
            transform.localRotation = Quaternion.Euler(0, -180, 15);
        }

    }
}
