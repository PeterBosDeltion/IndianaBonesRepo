using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : TriggerdObjects {
    public ParticleSystem fire;
    
    void Start()
    {
        fire = GetComponentInChildren<ParticleSystem>();
        fire.Stop();
    }

	public override void TriggerFunctionality()
	{
        //GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

        if (!fire.isPlaying)
        {
            fire.Play();
        }
        else
        {
            fire.Stop();
        }

        //if (GetComponent<Renderer>().material.color != Color.yellow)
        //{
        //    GetComponent<Renderer>().material.color = Color.yellow;
        //}
        //else
        //{
        //    GetComponent<Renderer>().material.color = Color.black;
        //}

    }
}
