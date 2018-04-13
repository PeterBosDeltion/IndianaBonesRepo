using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLockWheel : TriggerdObjects {
    public int currentSelected = -1;

    public List<int> combination = new List<int>();
    public GameObject myArrow;
	// Use this for initialization
	void Start () {
        foreach (Transform t in transform)
        {
            if(t.name == "Arrow_Indicator")
            {
                myArrow = t.gameObject;
            }
        }
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
            currentSelected = 1;
            //GetComponent<ObjectDescriptor>().descriptions.Clear();
            //GetComponent<ObjectDescriptor>().descriptions.Add("" + currentSelected);
        }

        if(currentSelected == 1)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 195);

        }
        else if (currentSelected == 2)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 225);

        }
        else if (currentSelected == 3)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 255);

        }
        else if (currentSelected == 4)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 285);
        }
        else if (currentSelected == 5)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 315);

        }
        else if (currentSelected == 6)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 345);

        }
        else if (currentSelected == 7)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 375);

        }
        else if (currentSelected == 8)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 405);

        }
        else if (currentSelected == 9)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 435);

        }
        else if (currentSelected == 10)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 465);

        }
        else if (currentSelected == 11)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 495);

        }
        else if (currentSelected == 12)
        {
            myArrow.transform.localRotation = Quaternion.Euler(0, -360, 525);
        }

    }
}
