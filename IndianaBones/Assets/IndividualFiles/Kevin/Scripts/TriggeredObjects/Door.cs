using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TriggerdObjects {


	public bool costsKey;
	public bool left;
	public bool rotate;
	
	void Update()
	{
		if(rotate == true)
		{
			if(left == true)
			{
				print(transform.eulerAngles);
				transform.Rotate(Vector3.forward * Time.deltaTime * -40);
				if(transform.rotation.eulerAngles.y <= 250)
				{
					rotate = false;
				}
			}
			else
			{
				transform.Rotate(Vector3.forward * Time.deltaTime * 40);
				if(transform.rotation.eulerAngles.y >= 110)
				{
					rotate = false;
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
			rotate = true;
		}
	}
}
