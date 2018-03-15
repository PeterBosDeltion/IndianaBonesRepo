using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : TriggerdObjects {
    public float timeUntilDestroyed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.GetComponent<Player>().Death();
            Destroy(gameObject);
        }
    }

    public override void TriggerFunctionality()
    {
        StartDestroyTimer();
    }

    public void StartDestroyTimer()
    {
        StartCoroutine(DestroyBoulder());
    }

    IEnumerator DestroyBoulder()
    {
        yield return new WaitForSeconds(timeUntilDestroyed);
        Destroy(gameObject);
    }
}
