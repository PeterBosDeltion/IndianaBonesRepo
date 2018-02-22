using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {

	public bool move;
	private GameManager gameManager;

	public Resolution[] reselutions;
	public TMP_Dropdown resolutionDropdown;
	void Start()
	{
		gameManager = GameObject.FindObjectOfType<GameManager>();
		resolutionDropdown.ClearOptions();
		reselutions = Screen.resolutions;
		List<string> options = new List<string>();
		int currentRes = 0;
		int myRes = 0;
		foreach(Resolution res in reselutions)
		{
			options.Add(res.width + "X" + res.height);
			currentRes += 1;
			if(res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height)
			{
				myRes = currentRes;
			}
		}
		
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = myRes;
		resolutionDropdown.RefreshShownValue();
	}
	void Update()
	{
		if(move == true)
		{
			Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,new Vector3(490, 210, 700),20);
		}
		else
		{
			Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,new Vector3(490, 210, -300),20);
		}
	}
	public void PlayGame()
	{
		GameManager.ChangeScene(1);
	}

	public void Options()
	{
		move = true;
	}

	public void Quit()
	{
		GameManager.Quit();
	}
	
	public void ChangeVolume(float volume)
	{
		gameManager.GameVolume(volume);
	}

	public void ChangeQuality(int qualityIndex)
	{
		gameManager.gameQualityIndex = qualityIndex;
	}

	public void ChangeReselution(int resolutionIndex)
	{
		gameManager.resolution = reselutions[resolutionIndex];
	}
	public void AcceptUIOptions()
	{
		gameManager.QualityOptionsUpdate();
		BackToMenu();
	}

	public void ChangeScreenMode(int screenModeIndex)
	{
		print(screenModeIndex);
		if(screenModeIndex == 0)
		{
			gameManager.screenMode = true;
		}
		else if(screenModeIndex == 1)
		{
			gameManager.screenMode = false;
		}
	}

	public void BackToMenu()
	{
		move = false;
	}
}
