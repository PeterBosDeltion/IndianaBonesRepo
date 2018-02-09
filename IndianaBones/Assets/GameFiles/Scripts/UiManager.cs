using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

	public GameObject pauseMenuPannel;

	void Update()
	{
		if(Input.GetButtonDown("ESC") && !pauseMenuPannel.activeSelf)
		{
			print("ok");
			pauseMenuPannel.SetActive(true);
			GameManager.ToggleTimeScale();
		}
		else if(Input.GetButtonDown("ESC") && pauseMenuPannel.activeSelf)
		{
			print("ok2");
			pauseMenuPannel.SetActive(false);
			GameManager.ToggleTimeScale();
		}
	}
	public void Resume()
	{
		pauseMenuPannel.SetActive(false);
		GameManager.ToggleTimeScale();
	}
	public void Options()
	{

	}
	public void Quit()
	{
		GameManager.Quit();
	}
	

	
}
