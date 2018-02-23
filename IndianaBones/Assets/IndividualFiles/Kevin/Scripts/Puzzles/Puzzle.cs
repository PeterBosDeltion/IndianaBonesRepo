using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour {
	public bool returnBool;
	public abstract bool PuzzleTrigger(int trigger);
}
