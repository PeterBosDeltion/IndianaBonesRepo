using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformingButton : TriggerdObjects {
    public List<GameObject> allPlatforms = new List<GameObject>();
    public List<List<GameObject>> triggerSequences = new List<List<GameObject>>();
    public float extendInterval;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        StartCoroutine(Triggerplatforms());
    }

    IEnumerator Triggerplatforms()
    {
        foreach (List<GameObject> l in triggerSequences)
        {
            yield return new WaitForSeconds(extendInterval);

            foreach (GameObject g in l)
            {
                g.SetActive(false);
            }
        }
    }
}
