using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntryChecker : MonoBehaviour {
    public bool left;
	// Use this for initialization
	void Start () 
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player p = other.GetComponent<Player>();

            if(p != null)
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
            else
            {
                Debug.LogError("Variable p (Player) is null, Script: RoomEntryChecker");
            }
         
        }
    }
}
