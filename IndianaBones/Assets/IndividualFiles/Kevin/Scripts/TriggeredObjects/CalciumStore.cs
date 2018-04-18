using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalciumStore : TriggerdObjects {

	void Start()
	{
		partsLeft = outlineChilds.Count;
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	public override void TriggerFunctionality()
	{
		if(player.coins != 0)
		{
			player.coins -= 1;
			SaveTrigger.coinsSave -= 1;
			player.milk += 1;
			SaveTrigger.milkSave += 1;
			player.CallUIUpdate();
		}
		else if(player.coins == 0)
		{
			player.SetText("No mony no lifu", 0, false);
		}
	}
}
