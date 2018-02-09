using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public void PlayGame()
	{
		GameManager.ChangeScene(1);
	}

	public void Options()
	{

	}

	public void Quit()
	{
		GameManager.Quit();
	}
}
