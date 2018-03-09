﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour {
    public bool hasKey;
    public int currentLives;
    public int maxLives = 3;
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
        currentLives = maxLives;
        beginingRoom = transform.position;
        descriptionText = GetComponentInChildren<TextMeshProUGUI>();
        uiManager = GameObject.FindObjectOfType<UiManager>();

        if(GameManager.gm.currentData != null)
        {
            hasKey = GameManager.gm.currentData.hasKey;
            currentLives = GameManager.gm.currentData.currentLives;
            maxLives = GameManager.gm.currentData.maxLives;
            coins = GameManager.gm.currentData.coins;
            milk = GameManager.gm.currentData.milk;
            bones = GameManager.gm.currentData.bones;
        }
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
            SaveTrigger.currentLivesSave -=1;
            if(uiManager != null)
            {
                uiManager.UpdateValues();
            }
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
            GameManager.gm.LoadGameState();
        }
    }

    public void DrinkMilk()
    {
        if(currentLives < maxLives)
        {
            currentLives += 1;
            SaveTrigger.currentLivesSave += 1;
        }
    }

    public void ConsumeBone()
    {
        maxLives += 1;
        SaveTrigger.maxLivesSave += 1;
        currentLives += 1;
        SaveTrigger.currentLivesSave += 1;
        uiManager.AddLive();
    }

    public void SetText(string s, float extraTime)
    {
        if (!displayingText)
        {
            StartCoroutine(SetPlayerDescriptionText(s, extraTime));
            
        }
    }

    private IEnumerator SetPlayerDescriptionText(string textToShow, float extraTime)
    {
        displayingText = true;
        descriptionText.text = "" + textToShow;
        yield return new WaitForSeconds(textDisplayTime + extraTime);
        descriptionText.text = "";
        displayingText = false;
    }
}
