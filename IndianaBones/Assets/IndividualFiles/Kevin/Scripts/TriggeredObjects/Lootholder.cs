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
	public Player player;

	void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	public override void TriggerFunctionality()
	{
		if(currentCollectable == Collectables.Bone)
		{
			player.bones += 1;
		}

		if(currentCollectable == Collectables.Coin)
		{
			player.coins += 1;
		}

		if(currentCollectable == Collectables.Key)
		{
			player.hasKey = true;
		}

		if(currentCollectable == Collectables.Milk)
		{
			player.milk += 1;
		}
	}
}
