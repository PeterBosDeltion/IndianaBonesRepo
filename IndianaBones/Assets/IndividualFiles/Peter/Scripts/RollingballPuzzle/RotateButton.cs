using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : TriggerdObjects {
    public List<GameObject> thingsToRotate = new List<GameObject>();
    private bool fookinRotation;
    public bool turnLeft;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (fookinRotation)
        {
            foreach (GameObject g in thingsToRotate)
            {
                if (turnLeft)
                {
                    g.transform.Rotate(Vector3.forward * 150 * Time.deltaTime);
                }
                else
                {
                    g.transform.Rotate(Vector3.forward * -150 * Time.deltaTime);
                }
            }
        }
	}

    public override void TriggerFunctionality()
    {
        RotateThings();
    }

    public void RotateThings()
    {
        StartCoroutine(Boool());
    }

    IEnumerator Boool()
    {
        fookinRotation = true;
        yield return new WaitForSeconds(0.1F);
        fookinRotation = false;
    }

    public void InvertDirection()
    {
        if (turnLeft)
        {
            turnLeft = false;
        }
        else
        {
            turnLeft = true;
        }
    }


}
