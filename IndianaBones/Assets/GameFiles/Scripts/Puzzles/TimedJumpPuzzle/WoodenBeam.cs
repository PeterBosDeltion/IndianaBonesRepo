using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBeam : TriggerdObjects {

	public enum BeamAction
	{
		Instant,
		Gradual,
		AfterTime,
		StayInPlace
	}
	
	public BeamAction state;
	public float afterTime;
	// gradual == snelheid van animation tijdes gradual state, 1 is max speed
	public float gradual;
	public float instant;
	public float gradualWaitTime;
	public Animator beam;
	public bool startStayInPlaceStateExtended;

    public AudioSource source;
    public AudioClip extendClip;
    public AudioClip retractClip;

    private GameManager gm;

	void Start()
	{
        gm = FindObjectOfType<GameManager>();

		beam = GetComponent<Animator>();
        source = gameObject.AddComponent<AudioSource>();

        source.playOnAwake = false;
        extendClip = gm.pistonExtend;
        retractClip = gm.pistonRetract;

        if (startStayInPlaceStateExtended == true)
		{
			if(state == BeamAction.StayInPlace)
			{
				TriggerFunctionality();
			}
			else
			{
				Debug.LogError("Wrong state, switch to StayInPlace");
			}
		}
	}
	public override void TriggerFunctionality()
	{
		if(state == BeamAction.AfterTime)
		{
			beam.SetTrigger("Trigger");
			StartCoroutine(BeamTimer(afterTime));
            ExtendAudio();
            
		}

        if (state == BeamAction.Gradual)
		{
			beam.SetTrigger("Trigger");
			StartCoroutine(BeamTimer(instant));
            ExtendAudio();
		}
        if (state == BeamAction.Instant)
		{
			beam.SetTrigger("Trigger");
			StartCoroutine(BeamTimer(instant));
            ExtendAudio();
		}
        if (state == BeamAction.StayInPlace)
		{
			beam.SetTrigger("Trigger");
            ExtendAudio();
		}
    }

    private void ExtendAudio()
    {
        source.clip = extendClip;
        source.Play();
    }

	public IEnumerator BeamTimer (float time)
	{
		yield return new WaitForSeconds(time);

        source.clip = retractClip;
        source.Play();

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
