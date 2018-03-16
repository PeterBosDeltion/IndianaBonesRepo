using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecterArrow : MonoBehaviour {
    public LightsPuzzle myPuzzle;
    public int horPos = 1;
    public int vertPos = 1;

    public int maxHorPos = 5;
    public int maxVertPos = 5;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void Trigger(bool moveRight)
    {
        if (gameObject == myPuzzle.horArrow)
        {
            myPuzzle.MoveHorizontalArrow(moveRight);
        }
        else if (gameObject == myPuzzle.vertArrow)
        {
            myPuzzle.MoveVerticalArrow();
        }
    }
}
