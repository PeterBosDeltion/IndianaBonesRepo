using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrap : TriggerdObjects {
    [Header("Own variables")]
    public GameObject emptyPos;
    public GameObject arrowPrefab;

    public float arrowSpeed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        GameObject g = Instantiate(arrowPrefab, emptyPos.transform.position, transform.rotation);
        
        Rigidbody rb = g.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddForce(transform.forward * arrowSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(g);
            Debug.LogError("Dart arrow prefab does not have rigidbody, Script:DartTrap");
        }
        Destroy(g, 4.0F);

    }
}
