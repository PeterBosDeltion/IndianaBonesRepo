using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsPuzzle : TriggerdObjects {
    public List<GameObject> lights = new List<GameObject>();
    public GameObject horArrow;
    public GameObject vertArrow;

    public GameObject selectedLight;
    public Material emisiveYellow;
    public Material soulBlack;
    private GameObject g;

    public bool useDebugLight;
    // Use this for initialization
    void Start () {
        GameObject[] lts = GameObject.FindGameObjectsWithTag("TestLights");
        foreach (GameObject q in lts)
        {
            lights.Add(q);
        }

        selectedLight = SelectLight(horArrow.GetComponent<SelecterArrow>().horPos, vertArrow.GetComponent<SelecterArrow>().vertPos);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveHorizontalArrow(bool moveRight)
    {
        SelecterArrow arrow = horArrow.GetComponent<SelecterArrow>();
        if (arrow.horPos <= arrow.maxHorPos && moveRight)
        {
            arrow.horPos++;
        }
        else if(arrow.horPos > 0 && !moveRight)
        {
            arrow.horPos--;
        }
        if (arrow.horPos > arrow.maxHorPos)
        {
            arrow.horPos = 1;
        }
        else if(arrow.horPos <= 0)
        {
            arrow.horPos = arrow.maxHorPos;
        }


        selectedLight = SelectLight(arrow.horPos, vertArrow.GetComponent<SelecterArrow>().vertPos);
        horArrow.transform.position = new Vector3(selectedLight.transform.position.x, horArrow.transform.position.y, horArrow.transform.position.z);


        if (useDebugLight)
        {
            foreach (GameObject w in lights)
            {
                if (w.GetComponent<Renderer>().material.color != Color.blue)
                {

                    w.GetComponent<Renderer>().material = soulBlack;
                }
            }

            selectedLight.GetComponent<Renderer>().material = emisiveYellow;
        }
      
    }

    GameObject SelectLight(int hPos, int vPos)
    {
        foreach (GameObject t in lights)
        {
            Licht l = t.GetComponent<Licht>();
            if (l.horPos == hPos && l.vertPos == vPos)
            {
                g = t.gameObject;
            }
        }

        return g;

    }

    public void MoveVerticalArrow()
    {
        SelecterArrow arrow = vertArrow.GetComponent<SelecterArrow>();
        if (arrow.vertPos <= arrow.maxVertPos)
        {
            arrow.vertPos++;
        }
        if (arrow.vertPos > arrow.maxVertPos)
        {
            arrow.vertPos = 1;
        }


        selectedLight = SelectLight(horArrow.GetComponent<SelecterArrow>().horPos, arrow.vertPos);
        vertArrow.transform.position = new Vector3(vertArrow.transform.position.x, selectedLight.transform.position.y, vertArrow.transform.position.z);

        if (useDebugLight)
        {
            foreach (GameObject w in lights)
            {
                if (w.GetComponent<Renderer>().material.color != Color.blue)
                {

                    w.GetComponent<Renderer>().material = soulBlack;
                }
            }

            selectedLight.GetComponent<Renderer>().material = emisiveYellow;
        }

    }

    public override void TriggerFunctionality()
    {
        selectedLight.GetComponent<TriggerdObjects>().TriggerFunctionality();
    }
}
