using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntryChecker : MonoBehaviour {
    public bool left;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (left)
            {
                other.GetComponent<Player>().enteredLeft = true;
            }
            else
            {
                other.GetComponent<Player>().enteredLeft = false;
            }
        }
    }
}
