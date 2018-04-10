using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrapArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Player")
        {
            col.transform.GetComponent<Player>().Death();
        }

        if(col.transform.tag == "Boulder")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.transform.GetComponent<Collider>(), true);
        }

        Destroy(gameObject);
    }
}
