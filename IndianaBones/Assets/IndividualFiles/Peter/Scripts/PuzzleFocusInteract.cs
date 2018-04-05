using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]

public class PuzzleFocusInteract : MonoBehaviour {
    public GameObject focusPoint;
    public float focusDuration = 3;
    public float extraZoffset;

    public bool impairMovement;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerMovement plm = other.GetComponent<PlayerMovement>();
            if (Input.GetButtonDown("E"))
            {
                if (impairMovement)
                {
                    plm.enabled = false;
                }

                if (!Camera.main.GetComponent<PlayerCamera>().focussing)
                {
                    Camera.main.GetComponent<PlayerCamera>().PuzzleFocus(focusPoint, focusDuration, extraZoffset);
                    Camera.main.GetComponent<PlayerCamera>().focussing = true;
                }
            }

            if(plm.x < -.6F || plm.x > .6F && !Camera.main.GetComponent<PlayerCamera>().focusPlayer)
            {
                Camera.main.GetComponent<PlayerCamera>().focussing = false;
                Camera.main.GetComponent<PlayerCamera>().focusPlayer = true;
            }
        }
       
    }
}
