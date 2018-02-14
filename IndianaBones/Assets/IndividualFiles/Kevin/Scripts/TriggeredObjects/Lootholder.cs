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
			player.CallUIUpdate();
		}

		if(currentCollectable == Collectables.Coin)
		{
			player.coins += 1;
			player.CallUIUpdate();
		}

		if(currentCollectable == Collectables.Key)
		{
			player.hasKey = true;
			player.CallUIUpdate();
		}

		if(currentCollectable == Collectables.Milk)
		{
			player.milk += 1;
			player.CallUIUpdate();
		}
		}
	}
}
