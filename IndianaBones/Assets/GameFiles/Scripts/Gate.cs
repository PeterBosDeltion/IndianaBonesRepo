﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : TriggerdObjects {

	public bool partOfPath;

	void Start()
	{
		if(partOfPath == true)
		{
			if(GameManager.gm.currentData != null)
			{
				if(GameManager.gm.currentData.finishedPath.Length != 0)
				{
					bool finishedGame = true;
					foreach (bool path in GameManager.gm.currentData.finishedPath)
					{
						print(path);
						if(path == false)
						{
							finishedGame = false;
						}
					}
					if(finishedGame == true)
					{
						TriggerFunctionality();
					}
				}
			}
		}
	}


	public override void TriggerFunctionality()
	{
		GetComponent<Animator>().SetTrigger("Trigger");
	}
	
}
