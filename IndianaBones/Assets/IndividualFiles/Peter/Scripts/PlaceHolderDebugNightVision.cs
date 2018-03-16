using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolderDebugNightVision : MonoBehaviour {
    public GameObject licht;

    public Color white = Color.white;
    public Color green = new Color(100, 161, 65);
	// Use this for initialization
	void Start () {
        foreach (Transform t in transform)
        {
            if(t.name == "Directional light")
            {
                licht = t.gameObject;
            }
        }

        licht.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("n"))
        {
            if (!licht.activeSelf)
            {
                licht.SetActive(true);
            }
            else
            {
                licht.SetActive(false);
            }
        }
        if (Input.GetKeyDown("m"))
        {
            if (licht.activeSelf)
            {
                if(licht.GetComponent<Light>().color == Color.white)
                {
                    licht.GetComponent<Light>().color = green;
                }
                else
                {
                    licht.GetComponent<Light>().color = Color.white;
                }
                
            }
        }
	}
}
