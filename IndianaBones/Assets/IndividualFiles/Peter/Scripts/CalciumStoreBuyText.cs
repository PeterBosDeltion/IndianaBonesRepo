using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CalciumStoreBuyText : MonoBehaviour {
    public TextMeshPro buyText;

	// Use this for initialization
	void Start () {
        buyText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buyText.enabled = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<Player>().descriptionText.text != "" || other.GetComponent<Player>().descriptionWorldText.text != "")
            {
                buyText.enabled = false;
            }
            else
            {
                buyText.enabled = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            buyText.enabled = false;
        }
    }
}
