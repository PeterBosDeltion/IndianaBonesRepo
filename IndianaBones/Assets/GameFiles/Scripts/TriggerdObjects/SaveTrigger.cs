using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : TriggerdObjects 
{
	private ToSave template;
	public static bool hasKeySave;
    public static int currentLivesSave = 3;
    public static int maxLivesSave = 3;
    public static int coinsSave;
    public static int milkSave;
    public static int bonesSave;
	public bool[] finishedPathSave;

	void Start()
	{
		if(GameManager.gm.currentData.finishedPath.Length != 0)
		{
			print("template data");
			template = GameManager.gm.currentData;
			finishedPathSave = template.finishedPath;
		}
		else
		{
			template = new ToSave();
			finishedPathSave = new bool[2];
		}
		currentLivesSave = template.currentLives;
		maxLivesSave = template.maxLives;
		coinsSave = template.coins;
		milkSave = template.milk;
		bonesSave = template.bones;
		hasKeySave = template.hasKey;
	}

	void OnTriggerEnter(Collider other)
	{
		TriggerFunctionality();
	}
	public override void TriggerFunctionality()
	{
		AssignVariables();
		GameManager.gm.SaveGameState(template);
		GameManager.gm.LoadGameState();
	}
	public void AssignVariables()
	{
		template.hasKey = hasKeySave;
		template.currentLives = currentLivesSave;
		template.maxLives = maxLivesSave;
		template.coins = coinsSave;
		template.milk = milkSave;
		template.bones = bonesSave;
		template.finishedPath = finishedPathSave;
	}
}
