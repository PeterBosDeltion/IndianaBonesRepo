using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightsOffPuzzle : Puzzle {

	public int gridWidth;
	public GameObject[,] lights;
	public int currentIndex = 0;
	public int hor = 0;
	public int ver = 0;


	public List<bool> lightsOnOff = new List<bool>();

	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
		lights = new GameObject[gridWidth,gridWidth];
	}

	public override void PuzzleTrigger(TriggerdObjects currentObject)
	{
		if(currentObject.puzzlePart == 1)
		{
			hor -= 1;
		}
		if(currentObject.puzzlePart == 2)
		{
//			lights[hor,ver].GetComponent<Lights>().toggleLights;
		}
		if(currentObject.puzzlePart == 3)
		{
			hor += 1;
		}
		if(currentObject.puzzlePart == 4)
		{
			ver -= 1;
		}
	}

	public void CheckLights(int trigger)
	{
		returnBool = true;
		if(lightsOnOff[trigger] ==false)
		{
			lightsOnOff[trigger] = true;
		}
		else
		{
			lightsOnOff[trigger] = false;
		}
		foreach (bool light in lightsOnOff)
		{
			if(light == false)
			{
				returnBool = false;
			}
		}
		puzzleManager.triggers -= 1;
		puzzleManager.done = returnBool;
	}
}
