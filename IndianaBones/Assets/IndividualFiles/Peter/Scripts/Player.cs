using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour {
    public bool hasKey;
    public int currentLives;
    public int maxLives;
    public int coins;
    public int milk;
    public int bones;
    public int textDisplayTime;
    private bool displayingText;

    private TextMeshProUGUI descriptionText;
	// Use this for initialization
	void Start () {
        descriptionText = GetComponentInChildren<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Death()
    {
        if(currentLives <= 0)
        {
            Debug.Log("Git gud u fucking casul scrub");
        }
        else if(currentLives > 0)
        {
            currentLives -= 1;
            //Go reset to the bathroom or something
        }
    }

    public void DrinkMilk()
    {
        if(currentLives < maxLives)
        {
            currentLives += 1;
        }
    }

    public void ConsumeBone()
    {
        maxLives += 1;
    }

    public void SetText(string s)
    {
        if (!displayingText)
        {
            StartCoroutine(SetPlayerDescriptionText(s));
            
        }
    }

    private IEnumerator SetPlayerDescriptionText(string textToShow)
    {
        displayingText = true;
        descriptionText.text = "" + textToShow;
        yield return new WaitForSeconds(textDisplayTime);
        descriptionText.text = "";
        displayingText = false;
    }


}
