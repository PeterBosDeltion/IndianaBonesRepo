﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectDescriptor : MonoBehaviour {
    [TextArea(15, 20)]
    public List<string> descriptions = new List<string>();
    public TextMeshPro myNameText;

    public float extraDisplayTime;

    private Player player;
    public bool sign;
	// Use this for initialization
	void Start () {
        if(transform.tag != "Player")
        {
            myNameText = GetComponentInChildren<TextMeshPro>();
        }
        if (myNameText != null)
        {
            myNameText.text = gameObject.name;
            myNameText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Variable myNameText is null, Add world space canvas with text to children, Script: ObjectDescriptor");
        }
    

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {
        if(myNameText != null)
        {
            if (myNameText.isActiveAndEnabled && Input.GetKeyUp(KeyCode.LeftAlt))
            {
                myNameText.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Variable myNameText is null, Add world space canvas with text to children, Script: ObjectDescriptor");
        }

    }

    public void OnMouseOver()
    {
        if(myNameText != null)
        {
            if (!player.displayingText)
            {
                if (!myNameText.isActiveAndEnabled && Input.GetKey(KeyCode.LeftAlt))
                {
                    myNameText.gameObject.SetActive(true);
                }
            }
           
        }
        else
        {
            Debug.LogError("Variable myNameText is null, Add world space canvas with text to children, Script: ObjectDescriptor");
        }
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftAlt))
        {
            myNameText.gameObject.SetActive(false);
            if(player != null)
            {
                player.SetText(RandomStringFromList(), extraDisplayTime, sign);
            }
            else
            {
                Debug.LogError("Variable player is null, Script: ObjectDescriptor");
            }
        }
    }

    private string RandomStringFromList()
    {
        if(descriptions.Count > 0)
        {
            string s = descriptions[Random.Range(0, descriptions.Count)];
            return s;

        }
        else
        {
            Debug.LogError("Object contains no descriptions, Script: ObjectDescriptor");
            string s = null;
            return s;
        }


    }

    public void OnMouseExit()
    {
        if(myNameText != null)
        {
            if (myNameText.isActiveAndEnabled)
            {
                myNameText.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Variable myNameText is null, Add world space canvas with text to children, Script: ObjectDescriptor");
        }
    }
}
