using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : TriggerdObjects {
    public Bounce myContent;
    private AnimationClip clip;
    private bool waiting;
	
    void Start()
    {
        foreach (AnimationClip c in GetComponent<Animator>().runtimeAnimatorController.animationClips)
        {
            if(c.name == "ChestOpening_Anim")
            {
                clip = c;
            }
        }
    }
    public override void TriggerFunctionality()
    {
        GetComponent<Animator>().SetTrigger("Open");
        if(triggerd == false)
        {
            triggerd = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        if (!waiting)
        {
            waiting = true;
            yield return new WaitForSeconds(clip.length);
            myContent.TriggerFunctionality();
            waiting = false;
        }
    }
}
