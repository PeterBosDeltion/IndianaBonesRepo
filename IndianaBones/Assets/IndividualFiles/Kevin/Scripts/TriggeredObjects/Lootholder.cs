using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHolder : TriggerdObjects {

	public enum Collectables
	{
		Coin,
		Bone,
		Key,
		Milk

	}

	public Collectables currentCollectable;

	void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	public override void TriggerFunctionality()
	{
		if(triggerd == false)
		{
			triggerd = true;
			if(currentCollectable == Collectables.Bone)
			{
				player.bones += 1;
				SaveTrigger.bonesSave += 1;
				player.CallUIUpdate();
			}

			if(currentCollectable == Collectables.Coin)
			{
				print("Cashies");
				player.coins += 1;
				SaveTrigger.coinsSave += 1;
				player.CallUIUpdate();
			}

			if(currentCollectable == Collectables.Key)
			{
				player.hasKey = true;
				SaveTrigger.hasKeySave = true;
				player.CallUIUpdate();
			}

			if(currentCollectable == Collectables.Milk)
			{
				player.milk += 1;
				SaveTrigger.milkSave += 1;
				player.CallUIUpdate();
			}
		}
	}
}
