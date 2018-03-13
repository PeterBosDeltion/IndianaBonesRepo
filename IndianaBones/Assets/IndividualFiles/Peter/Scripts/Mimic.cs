using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : TriggerdObjects {
    private AnimationClip clip;
	public override void TriggerFunctionality()
	{

        GetComponent<Animator>().Play("Mimic");
        clip = GetComponent<AnimationClip>();
        Debug.Log(clip.name);

    }

    IEnumerator WaitforAnim()
    {
        yield return new WaitForSeconds(clip.length);
        //Player ded
    }
}
