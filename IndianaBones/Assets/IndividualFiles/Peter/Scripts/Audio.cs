using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : TriggerdObjects {
    public AudioSource sourceToPlay;
    private GameObject collisionOther;

    public enum State
    {
        Trigger,
        Interact,
        Start,

    }

    public State whenToPlay;
	// Use this for initialization
	void Start () {
		if(whenToPlay == State.Start)
        {
            sourceToPlay.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("E"))
        {
            if(collisionOther != null)
            {
                if(collisionOther.tag == "Player")
                {
                    if(whenToPlay == State.Interact)
                    {
                        sourceToPlay.Play();
                    }
                }
            }
        }
	}

    public void OnTriggerStay(Collider other)
    {
        collisionOther = other.gameObject;
    }

    public void OnTriggerExit(Collider other)
    {
        collisionOther = null;
    }

    public override void TriggerFunctionality()
    {
        if(whenToPlay == State.Trigger)
        {
            sourceToPlay.Play();
        }
    }
}
