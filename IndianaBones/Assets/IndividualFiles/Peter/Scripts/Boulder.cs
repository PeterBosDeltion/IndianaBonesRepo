using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : TriggerdObjects {
    public float timeUntilDestroyed;
    public List<GameObject> debris = new List<GameObject>();
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
            foreach (GameObject g in debris)
            {
                GameObject q = Instantiate(g, transform.position, Quaternion.identity);
                Destroy(q, 3.0F);
            }
            Destroy(gameObject);

            col.transform.GetComponent<Player>().Death();
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
        foreach (GameObject g in debris)
        {
            GameObject q = Instantiate(g, transform.position, Quaternion.identity);
            Destroy(q, 3.0F);
        }
        Destroy(gameObject);
    }
}
