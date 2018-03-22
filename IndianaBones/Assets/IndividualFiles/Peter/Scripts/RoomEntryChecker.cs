using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntryChecker : MonoBehaviour {
    public bool left;
    public GameObject nextRoom;
    public GameObject nextPos;
    private bool changedPos;

    public float xOffset = 5;
	// Use this for initialization
	void Start () 
    {

        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            Player p = other.GetComponent<Player>();
            p.currentRoom = nextRoom;

            if (p != null)
            {
                RoomBoundaryCalculator rmb = nextRoom.GetComponent<RoomBoundaryCalculator>();

                if(other.GetComponent<PlayerMovement>().x > 0)
                {
                    other.transform.position = new Vector3(nextRoom.GetComponent<RoomBoundaryCalculator>().leftSideBound.x, other.transform.position.y, other.transform.position.z);
                }
                else
                {
                    other.transform.position = new Vector3(nextRoom.GetComponent<RoomBoundaryCalculator>().rightSideBound.x, other.transform.position.y, other.transform.position.z);
                }
                if (left)
                {
                    other.GetComponent<Player>().enteredLeft = true;
                }
                else
                {
                    other.GetComponent<Player>().enteredLeft = false;
                }

            }

        }

        else
        {
            Debug.LogError("Variable p (Player) is null, Script: RoomEntryChecker");
        }
         
        }
    }

