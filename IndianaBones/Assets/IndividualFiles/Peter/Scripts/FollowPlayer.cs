using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;
    public float yOffset;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    void Move()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z);
    }
}
