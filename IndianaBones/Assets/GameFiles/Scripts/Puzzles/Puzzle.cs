using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour {
	public bool returnBool;
	public PuzzleManager puzzleManager;

	public bool puzzleDone;
	public abstract void PuzzleTrigger(TriggerdObjects currentObject);
}
