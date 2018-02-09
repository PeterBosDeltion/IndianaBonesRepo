using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectDescriptor : MonoBehaviour {
    public List<string> descriptions = new List<string>();
    public TextMeshPro myNameText;
	// Use this for initialization
	void Start () {
        myNameText = GetComponentInChildren<TextMeshPro>();
        myNameText.text = gameObject.name;
        myNameText.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (myNameText.isActiveAndEnabled && Input.GetKeyUp(KeyCode.LeftAlt))
        {
            myNameText.enabled = false;
        }
    }

    public void OnMouseOver()
    {
        if (!myNameText.isActiveAndEnabled && Input.GetKey(KeyCode.LeftAlt))
        {
            myNameText.enabled = true;
        }
    }

    public void OnMouseExit()
    {
        if (myNameText.isActiveAndEnabled)
        {
            myNameText.enabled = false;
        }
    }
}
