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

	public abstract void TriggerFunctionality();

	public virtual void OutlineShaderToggle()
	{
	}
}
