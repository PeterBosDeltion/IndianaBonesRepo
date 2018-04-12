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
        if (other.gameObject.tag == "Player")
        {

            Player p = other.GetComponent<Player>();
            //PlayerMovement plm = other.GetComponent<PlayerMovement>();

            if (p != null)
            {
                if (p.enteredLeft)
                {
                    p.beginingRoom = new Vector3(other.transform.position.x + .4F, other.transform.position.y, other.transform.position.z);
                }
                else
                {
                    p.beginingRoom = new Vector3(other.transform.position.x - .4F, other.transform.position.y, other.transform.position.z);
                }
                p.currentRoom = gameObject;
            }
            else
            {
                Debug.LogError("Variable p (Player) is null, Script: Room");
            }


            //    if(plm != null)
            //    {
            //        if (plm.speed != plm.startSpeed)
            //        {
            //            plm.speed = plm.startSpeed;
            //        }

            //        float ogSpeed = other.GetComponent<PlayerMovement>().startSpeed;

            //        plm.canSprint = false;
            //        plm.startSpeed *= 2;

            //        StartCoroutine(ReturnSpeed(other.gameObject, ogSpeed));
            //    }
            //    else
            //    {
            //        Debug.LogError("Variable plm (PlayerMovement) is null, Script: Room");
        }

        }
    }

            //IEnumerator ReturnSpeed(GameObject player, float ogSpeed)
            //{
            //    PlayerMovement plm = player.GetComponent<PlayerMovement>();
            //    yield return new WaitForSeconds(0.6F);

            //    if(plm != null)
            //    {
            //        StartCoroutine(plm.SprintCooldown());
            //        plm.startSpeed = ogSpeed;
            //    }
            //    else
            //    {
            //        Debug.LogError("Variable plm (PlayerMovement) is null, Script: Room");
            //    }

            //}
        
