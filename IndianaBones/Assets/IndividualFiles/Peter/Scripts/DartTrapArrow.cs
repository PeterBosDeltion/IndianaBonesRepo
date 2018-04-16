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
        Destroy(gameObject);
    }
}
