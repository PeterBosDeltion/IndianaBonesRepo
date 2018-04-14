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
	public bool[] finishedPathSave;

	void Start()
	{
		// template = GameObject.FindObjectOfType<GameManager>().GetComponent<ToSave>();
		template = new ToSave();
		finishedPathSave = new bool[2];
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
