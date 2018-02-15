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

    public bool enteredLeft;
    public Vector3 beginingRoom;
    public GameObject currentRoom;

    private TextMeshProUGUI descriptionText;

    private UiManager uiManager;
	// Use this for initialization
	void Start () {
        beginingRoom = transform.position;
        descriptionText = GetComponentInChildren<TextMeshProUGUI>();
        uiManager = GameObject.FindObjectOfType<UiManager>();
    }

    public void CallUIUpdate()
    {
        uiManager.UpdateValues();
    }
    public void Death()
    {
        if(currentLives > 0)
        {
            currentLives -= 1;
            uiManager.UpdateValues();
            Camera.main.GetComponent<PlayerCamera>().ResetCam();
            if (enteredLeft)
            {
                transform.position = beginingRoom + new Vector3(2, 0, 0);
            }
            else
            {
                transform.position = beginingRoom + new Vector3(-2, 0, 0);
            }
            //Go reset to the bathroom or something
        }
        if(currentLives <= 0)
        {
            Debug.Log("Git gud u fucking casul scrub");
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
