using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public float yOffset;
    public float zOffset;
    public float speed;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveToPlayer();
	}

    void MoveToPlayer()
    {
        if(player.transform.position.x > player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().leftSideBound.x && player.transform.position.x < player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().rightSideBound.x)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z + zOffset), speed);
        }
    }

    public void ResetCam()
    {
        if (player.GetComponent<Player>().enteredLeft)
        {
            transform.position = new Vector3(player.GetComponent<Player>().beginingRoom.x + player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().xOffset, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
        }
        else
        {
            transform.position = new Vector3(player.GetComponent<Player>().beginingRoom.x - player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().xOffset, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
        }
    }
}
