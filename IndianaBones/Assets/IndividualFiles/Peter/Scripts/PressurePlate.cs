using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : InteractableObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //GetComponent<Animation>().Play();
            Trigger();
        }
    }
}
