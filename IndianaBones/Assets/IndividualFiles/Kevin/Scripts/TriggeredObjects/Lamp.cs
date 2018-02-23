using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : TriggerdObjects {
    public ParticleSystem fire;
    
    void Start()
    {
        fire = GetComponentInChildren<ParticleSystem>();
    }

	public override void TriggerFunctionality()
	{
        if (!fire.isPlaying)
        {
            fire.Play();
        }
        else
        {
            fire.Stop();
        }
    }
}
