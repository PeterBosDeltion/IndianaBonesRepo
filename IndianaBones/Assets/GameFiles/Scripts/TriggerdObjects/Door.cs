using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TriggerdObjects {


	public bool costsKey;
	public bool left;

	public int path;
	public bool partOfPath;
	void Start()
	{
		if(partOfPath == true)
		{
			if(GameManager.gm.currentData != null)
			{
				print("Data found");
				if(GameManager.gm.currentData.finishedPath.Length != 0)
				{
					
					if(GameManager.gm.currentData.finishedPath[path] == true)
					{
						triggerd = true;
						TriggerFunctionality();
					}
				}
			}
		}
	}

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
			GetComponent<Animator>().SetBool("Left",left);
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
