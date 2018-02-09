using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

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
            Destroy(gameObject, 2.0F);
        }
    }
}
