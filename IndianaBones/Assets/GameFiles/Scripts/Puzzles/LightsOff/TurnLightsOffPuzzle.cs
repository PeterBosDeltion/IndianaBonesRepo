using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightsOffPuzzle : Puzzle {

	public int gridWidth;
	public GameObject[,] lights;
	public int currentIndex = 0;
	public int hor = 0;
	public int ver = 0;

	public GameObject arrowHor;
	public GameObject arrowVer;


	public List<bool> lightsOnOff = new List<bool>();

	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
		lights = new GameObject[gridWidth,gridWidth];
	}


	public void TriggerAllLights()
	{
		lights [hor,ver].GetComponent<Lamp>().TriggerFunctionality();
		puzzleManager.triggers += 1;

		if(hor + 1 <= gridWidth)
		{
			lights [hor += 1,ver].GetComponent<Lamp>().TriggerFunctionality();
			puzzleManager.triggers += 1;
		}
		if(hor - 1 >= 0)
		{
			lights [hor -= 1,ver].GetComponent<Lamp>().TriggerFunctionality();
			puzzleManager.triggers += 1;
		}
		if(ver + 1 <= gridWidth)
		{
			lights [hor,ver += 1].GetComponent<Lamp>().TriggerFunctionality();
			puzzleManager.triggers += 1;
		}
		if(ver - 1 >= 0)
		{
			lights [hor,ver -= 1].GetComponent<Lamp>().TriggerFunctionality();
			puzzleManager.triggers += 1;
		}
	}

	public override void PuzzleTrigger(TriggerdObjects currentObject)
	{
		if(currentObject.GetComponent<Lamp>())
		{
			CheckLights(currentObject.puzzlePart);
		}
		else if(currentObject.puzzlePart == 1)
		{
			if(hor == 0)
			{	
				arrowHor.transform.Translate(4,0,0);
				hor  = gridWidth;
			}
			else
			{
				arrowHor.transform.Translate(-1,0,0);
				hor -= 1;
			}
		}
		else if(currentObject.puzzlePart == 2)
		{
			TriggerAllLights();
		}
		else if(currentObject.puzzlePart == 3)
		{
			if(hor == gridWidth)
			{
				arrowHor.transform.Translate(-4,0,0);
				hor = 0;
			}
			else
			{
				arrowHor.transform.Translate(1,0,0);
				hor += 1;
			}
		}
		else if(currentObject.puzzlePart == 4)
		{
			if(ver == gridWidth)
			{
				arrowVer.transform.Translate(0,-4,0);
				ver = 0;
			}
			else
			{
				arrowVer.transform.Translate(0,1,0);
				ver -= 1;
			}
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
