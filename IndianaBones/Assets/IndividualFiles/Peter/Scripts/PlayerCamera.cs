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
        if(player != null)
        {
            if (player.transform.position.x > player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().leftSideBound.x && player.transform.position.x < player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().rightSideBound.x)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z + zOffset), speed);
            }
            if (transform.position.y > player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().downSideBound.y && transform.position.y < player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().upSideBound.y)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y + yOffset, player.transform.position.z + zOffset), speed);
            }
        }
        else
        {
            Debug.LogError("player variable is null, Script:PlayerCamera");
        }

    }

    public void ResetCam()
    {
        if(player != null)
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
        else
        {
            Debug.LogError("player variable is null, Script:PlayerCamera");
        }
      
    }
}
