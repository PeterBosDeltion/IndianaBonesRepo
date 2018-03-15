using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : TriggerdObjects {
    private AnimationClip clip;
	public override void TriggerFunctionality()
	{

        clip = GetComponentInParent<Animation>().clip; //Probably need to change this to not be in parent but it is for placeholder purposes
        Animation a = GetComponentInParent<Animation>();
        if(a != null)
        {
            a.Play();
        }
        else
        {
            Debug.LogError("Variable a (Animation) is null, Script: Mimic");
        }
        StartCoroutine(WaitforAnim());

    }

    IEnumerator WaitforAnim()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            p.GetComponent<PlayerMovement>().enabled = false;
            if(clip != null)
            {
                yield return new WaitForSeconds(clip.length);
                p.GetComponent<Player>().Death();
                p.GetComponent<PlayerMovement>().enabled = true;
            }
            else
            {
                Debug.LogError("Variable clip (AnimationClip) is null, Script: Mimic");
            }
        }
        else
        {
            Debug.LogError("Variable p (player) is null, Script: Mimic");
        }
     

        //Player ded
    }
}
