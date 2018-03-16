using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licht : TriggerdObjects {
    public int horPos;
    public int vertPos;

    public List<GameObject> neighbours = new List<GameObject>();
    public bool on;
	// Use this for initialization
	void Start () {
		if(neighbours.Count <= 0)
        {
            Debug.Log("Loner detected");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {

        foreach (GameObject q in neighbours)
        {
            Licht g = q.GetComponent<Licht>();
            if (g.on)
            {
                g.on = false;
                g.GetComponent<Renderer>().material.color = Color.black;
            }
            else if (!g.on)
            {
                g.on = true;
                g.GetComponent<Renderer>().material.color = Color.green;
            }
        }
        if (on)
        {
            on = false;
            GetComponent<Renderer>().material.color = Color.black;

        }
        else if (!on)
        {
            on = true;
            GetComponent<Renderer>().material.color = Color.green;

        }
    }
}
