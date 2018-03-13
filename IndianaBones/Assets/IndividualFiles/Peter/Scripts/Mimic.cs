using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : TriggerdObjects {
    private AnimationClip clip;
	public override void TriggerFunctionality()
	{

        clip = GetComponentInParent<Animation>().clip;
        GetComponentInParent<Animation>().Play();
        StartCoroutine(WaitforAnim());

    }

    IEnumerator WaitforAnim()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        p.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(clip.length);
        p.GetComponent<Player>().Death();
        p.GetComponent<PlayerMovement>().enabled = true;

        //Player ded
    }
}
