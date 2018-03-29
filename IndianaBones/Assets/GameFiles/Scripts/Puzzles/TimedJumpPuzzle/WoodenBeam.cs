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
	// gradual == snelheid van animation tijdes gradual state, 1 is max speed
	public float gradual;
	public float instant;
	public float gradualWaitTime;
	public Animator beam;

	void Start()
	{
		beam = GetComponent<Animator>();
	}
	public override void TriggerFunctionality()
	{
		if(state == BeamAction.AfterTime)
		{
			beam.SetTrigger("Trigger");
			StartCoroutine(BeamTimer(afterTime));
		}

		if(state == BeamAction.Gradual)
		{
			beam.SetTrigger("Trigger");
			StartCoroutine(BeamTimer(instant));
		}
		if(state == BeamAction.Instant)
		{
			beam.SetTrigger("Trigger");
			StartCoroutine(BeamTimer(instant));
		}
	}
	public IEnumerator BeamTimer (float time)
	{
		yield return new WaitForSeconds(time);
		if(state == BeamAction.Gradual)
		{
			beam.speed = gradual;
		}
		beam.SetTrigger("Trigger");
		yield return new WaitForSeconds(gradualWaitTime);
		if(state == BeamAction.Gradual)
		{
			print("nu");
			beam.speed = 1;
		}
	}
}
