using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerdObjects : MonoBehaviour {

	public Player player;
	public PuzzleManager puzzleManager;
	public bool triggerd;
	public int puzzleNumber;
	public int puzzlePart;
	public Material outlineMat;
	public Material[] mats;
	public List<GameObject> outlineChilds = new List<GameObject>();
	bool outline = false;
	public bool noMoreUse;
	public int partsLeft;

	public abstract void TriggerFunctionality();

	public void OutlineShaderToggle()
	{
		if(triggerd != true)
		{
			foreach (GameObject child in outlineChilds)
			{
				mats = child.GetComponent<Renderer>().materials;
				if(mats[1] != outlineMat && outline != true)
				{
					mats[1] = outlineMat;
					partsLeft -= 1;
					if(partsLeft == 0)
					{
						outline = true;
					}
				}
				
				else
				{
					mats[1] = mats[0];
					partsLeft += 1;
					if(partsLeft == outlineChilds.Count)
					{
						outline = false;
					}
				}
				child.GetComponent<Renderer>().materials = mats;
			}
		}
	}
}
