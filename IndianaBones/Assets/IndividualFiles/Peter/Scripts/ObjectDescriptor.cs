using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectDescriptor : MonoBehaviour {
    public List<string> descriptions = new List<string>();
    public TextMeshPro myNameText;

    public float extraDisplayTime;

    private Player player;
	// Use this for initialization
	void Start () {
        myNameText = GetComponentInChildren<TextMeshPro>();
        myNameText.text = gameObject.name;
        myNameText.enabled = false;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftAlt))
        {
           player.SetText(RandomStringFromList(), extraDisplayTime);
        }
    }

    private string RandomStringFromList()
    {
        string s = descriptions[Random.Range(0, descriptions.Count)];
        return s;
    }

    public void OnMouseExit()
    {
        if (myNameText.isActiveAndEnabled)
        {
            myNameText.enabled = false;
        }
    }
}
