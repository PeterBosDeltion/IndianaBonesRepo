using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TriggerdObjects {


	public bool costsKey;
	public Player player;

	void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	public override void TriggerFunctionality()
	{
		if(costsKey == true)
		{
			player.hasKey = false;
		}
		GetComponent<Animation>().Play();
	}
}
