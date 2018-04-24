using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootsstepSound : MonoBehaviour {

    public AudioClip footStep;
    public AudioSource audioS;


	void Start ()
    {
		
	}

    void FootStep()
    {
        audioS.PlayOneShot(footStep);
    }
}
