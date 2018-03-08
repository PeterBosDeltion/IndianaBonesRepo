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
        rb.AddForce(transform.forward * arrowSpeed * Time.deltaTime);
        Destroy(g, 4.0F);

    }
}
