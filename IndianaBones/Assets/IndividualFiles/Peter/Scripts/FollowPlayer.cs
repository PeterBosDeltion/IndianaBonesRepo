using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;
    public float yOffset;
    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        yOffset = 1.4F;

        foreach (Transform t in transform)
        {
            if(t.name == "DescriptionWorldText")
            {
                player.GetComponent<Player>().descriptionWorldText = t.GetComponent<TextMeshPro>();
            }
            if (t.name == "NameText")
            {
                player.GetComponent<ObjectDescriptor>().myNameText = t.GetComponent<TextMeshPro>();
                player.GetComponent<ObjectDescriptor>().myNameText.text = "Indiana Bones";
            }
        }
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
