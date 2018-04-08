using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TriggerdObjects {


	public bool costsKey;
	public bool left;


	public override void TriggerFunctionality()
	{
		if(triggerd == false)
		{
			triggerd = true;
			if(costsKey == true)
			{
				player.hasKey = false;
			}
			StartCoroutine(MechanismTimer());
		}
		else
		{
			GetComponent<Animator>().SetBool("Close", true);
			GetComponent<Animator>().SetTrigger("TriggerDoor");
		}
	}

	IEnumerator MechanismTimer()
	{
		yield return new WaitForSeconds(1.5f);
		GetComponent<Animator>().SetBool("Left",left);
		GetComponent<Animator>().SetTrigger("TriggerDoor");
	}
}
