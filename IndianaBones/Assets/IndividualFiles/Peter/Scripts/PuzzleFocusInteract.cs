using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]

public class PuzzleFocusInteract : MonoBehaviour {
    public GameObject focusPoint;
    public float focusDuration = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay()
    {
        if (Input.GetButtonDown("E"))
        {
            Camera.main.GetComponent<PlayerCamera>().PuzzleFocus(focusPoint, focusDuration);
        }
    }
}
