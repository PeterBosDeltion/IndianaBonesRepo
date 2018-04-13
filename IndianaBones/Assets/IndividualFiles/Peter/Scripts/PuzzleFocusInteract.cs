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
            if (Input.GetButtonDown("E"))
            {
                if (impairMovement)
                {
                    other.GetComponent<PlayerMovement>().enabled = false;
                }

                if (!Camera.main.GetComponent<PlayerCamera>().focussing)
                {
                    Camera.main.GetComponent<PlayerCamera>().PuzzleFocus(focusPoint, focusDuration, extraZoffset);
                    Camera.main.GetComponent<PlayerCamera>().focussing = true;
                    Camera.main.GetComponent<PlayerCamera>().focusPlayer = false;
                }
            }

            if (!impairMovement)
            {
                if (other.GetComponent<PlayerMovement>().x < -.6F || other.GetComponent<PlayerMovement>().x > .6F && !Camera.main.GetComponent<PlayerCamera>().focusPlayer)
                {
                    Camera.main.GetComponent<PlayerCamera>().focussing = false;
                    Camera.main.GetComponent<PlayerCamera>().focusPlayer = true;
                }
            }
        }
       
    }
}
