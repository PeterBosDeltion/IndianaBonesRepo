using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowinvisPlatforms : TriggerdObjects {
    public List<GameObject> platforms = new List<GameObject>();
    public float showTime;
    private bool running;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        if (!running)
        {
            StartCoroutine(Show());
        }
    }

    IEnumerator Show()
    {
        running = true;
        foreach (GameObject g in platforms)
        {
            g.GetComponent<MeshRenderer>().enabled = true;
        }
        yield return new WaitForSeconds(showTime);
        foreach (GameObject g in platforms)
        {
            g.GetComponent<MeshRenderer>().enabled = false;
        }

        running = false;
    }
}
