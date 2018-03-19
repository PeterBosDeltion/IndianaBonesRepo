using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : TriggerdObjects 
{
	private ToSave template;
	public static bool hasKeySave;
    public static int currentLivesSave;
    public static int maxLivesSave;
    public static int coinsSave;
    public static int milkSave;
    public static int bonesSave;

	public static bool[] finishedPuzzlesSave;
	void Start()
	{
		template = GameObject.FindObjectOfType<GameManager>().GetComponent<ToSave>();
	}

	public override void TriggerFunctionality()
	{
		AssignVariables();
		GameManager.gm.SaveGameState();
		GameManager.gm.ChangeScene(1);
	}
	public void AssignVariables()
	{
		template.hasKey = hasKeySave;
		template.currentLives = currentLivesSave;
		template.maxLives = maxLivesSave;
		template.coins = coinsSave;
		template.milk = milkSave;
		template.bones = bonesSave;
		template.finishedPuzzles = finishedPuzzlesSave;
	}
}
