using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : TriggerdObjects {

	public bool rotate;
	void Start()
	{
		TriggerFunctionality();
	}
	void Update()
	{
		if(rotate == true)
		{
			transform.Rotate(Vector3.down * Time.deltaTime * 50);
			print(transform.localEulerAngles);
			if(transform.localEulerAngles.z >= 315)
			{
				rotate = false;
			}
		}
	}

	public override void TriggerFunctionality()
	{
		rotate = true;
	}
}
