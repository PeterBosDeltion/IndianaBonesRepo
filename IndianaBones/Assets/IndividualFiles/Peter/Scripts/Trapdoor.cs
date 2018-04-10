using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : TriggerdObjects {
    public Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        if(anim != null)
        {
            
            anim.Play("Trapdoor");
        }
        else
        {
            Debug.LogError("Variable anim (Animator) is null, Script: Trapdoor");
        }
        //gameObject.SetActive(false);
    }
}
