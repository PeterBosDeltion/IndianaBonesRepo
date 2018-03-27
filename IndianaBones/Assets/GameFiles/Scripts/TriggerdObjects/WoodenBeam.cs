using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBeam : TriggerdObjects {

	public enum BeamAction
	{
		Instant,
		Gradual,
		AfterTime
	}
	
	public BeamAction state;
	public float afterTime;
	public float gradual;
	public float instant;
	public Animator beam;

	void Start()
	{
		beam = GetComponent<Animator>();
	}

	void Update()
	{
		if(state == BeamAction.Instant)
		{
			print("update");
			// if(beam.)
			// {
			// 	beam.SetTrigger("Trigger");
			// }
		}
	}
	public override void TriggerFunctionality()
	{
		beam.SetTrigger("Trigger");
		if(state == BeamAction.AfterTime)
		{
			StartCoroutine(BeamTimer());
		}

		if(state == BeamAction.Gradual)
		{

		}
	}
	public IEnumerator BeamTimer ()
	{
		yield return new WaitForSeconds(afterTime);
		print("Triggerd reeeeeeee");
		beam.SetTrigger("Trigger");
	}
}
