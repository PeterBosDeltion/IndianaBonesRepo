using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    [Header("How to set up room")]
    [Header("1. Have room, add empty gameobject in center and give it raycaster tag.")]
    [Header("2. Add trigger colliders in doorways.")]
    [Header("3. Add empty objects in doorways, give trigger colliders, add roomentrychecker script and set bool to true if it is the left door.")]

    public bool boolthatdoesnothing;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().beginingRoom = other.transform.position;
            other.GetComponent<Player>().currentRoom = gameObject;

            if (other.GetComponent<PlayerMovement>().speed != other.GetComponent<PlayerMovement>().startSpeed)
            {
                other.GetComponent<PlayerMovement>().speed = other.GetComponent<PlayerMovement>().startSpeed;
            }
        
            float ogSpeed = other.GetComponent<PlayerMovement>().startSpeed;

            other.GetComponent<PlayerMovement>().canSprint = false;
            other.GetComponent<PlayerMovement>().startSpeed *= 2;

            StartCoroutine(ReturnSpeed(other.gameObject, ogSpeed));
        }
    }

    IEnumerator ReturnSpeed(GameObject player, float ogSpeed)
    {
        yield return new WaitForSeconds(0.6F);
       StartCoroutine(player.GetComponent<PlayerMovement>().SprintCooldown());
        player.GetComponent<PlayerMovement>().startSpeed = ogSpeed;
    }
}
