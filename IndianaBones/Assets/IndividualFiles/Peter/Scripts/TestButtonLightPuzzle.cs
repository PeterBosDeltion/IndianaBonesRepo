﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButtonLightPuzzle : MonoBehaviour {
    public List<Image> lightsAffected = new List<Image>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked()
    {
        foreach (Image i in lightsAffected)
        {
            if(i.color == Color.white)
            {
                i.color = Color.yellow;
            }
            else if (i.color != Color.white)
            {
                i.color = Color.white;
            }
        }
    }
}
