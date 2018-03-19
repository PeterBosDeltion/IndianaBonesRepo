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
	public List<GameObject> lightObjects = new List<GameObject>();
	public List<bool> lightsOnOff = new List<bool>();

	void Start()
	{
		puzzleManager = GameObject.FindObjectOfType<PuzzleManager>();
		lights = new GameObject[gridWidth,gridWidth];
		int indexH = 0;
		int indexV = 0;
		foreach(GameObject light in lightObjects)
		{
			lights.SetValue(light,indexH,indexV);
			if(indexH == 4)
			{
				indexV += 1;
				indexH = 0;
			}
			else
			{
				indexH += 1;
			}
		}
	}


	public void TriggerAllLights()
	{
		print(lights[hor,ver]);
		lights [hor,ver].GetComponent<Lamp>().TriggerFunctionality();
		puzzleManager.triggers += 1;

		if(hor + 1 < gridWidth)
		{
			lights [hor += 1,ver].GetComponent<Lamp>().TriggerFunctionality();
			hor -= 1;
			print("ok");
			puzzleManager.triggers += 1;
		}
		if(hor > 0)
		{
			lights [hor -= 1,ver].GetComponent<Lamp>().TriggerFunctionality();
			hor += 1;
			print("ok");
			puzzleManager.triggers += 1;
		}
		if(ver + 1 < gridWidth)
		{
			lights [hor,ver += 1].GetComponent<Lamp>().TriggerFunctionality();
			ver -= 1;
			print("ok");
			puzzleManager.triggers += 1;
		}
		if(ver > 0)
		{
			lights [hor,ver -= 1].GetComponent<Lamp>().TriggerFunctionality();
			ver += 1;
			print("ok");
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
				hor  = gridWidth - 1;
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
			if(hor == gridWidth - 1)
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
			if(ver == gridWidth - 1)
			{
				print(gridWidth);
				arrowVer.transform.Translate(0,-4,0);
				ver = 0;
			}
			else
			{
				arrowVer.transform.Translate(0,1,0);
				ver += 1;
			}
		}
	}

	public void CheckLights(int trigger)
	{
		returnBool = true;
		if(lightsOnOff[trigger] ==false)
		{
			print("stap 2");
			lightsOnOff[trigger] = true;
		}
		else
		{
			print("stap 3");
			lightsOnOff[trigger] = false;
		}
		print("tussen");
		foreach (bool light in lightsOnOff)
		{
			print("stap 4");
			if(light == false)
			{
				print("stap 5");
				returnBool = false;
			}
		}
		puzzleManager.triggers -= 1;
		puzzleManager.done = returnBool;
	}
}
