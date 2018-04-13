using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public float yOffset;
    public float zOffset;
    public float speed;
    private GameObject player;
    public bool focusPlayer;
    public bool focussing;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        focusPlayer = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (focusPlayer)
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        if(player != null)
        {
            if (player.transform.position.x >= player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().leftSideBound.x && player.transform.position.x <= player.GetComponent<Player>().currentRoom.GetComponent<RoomBoundaryCalculator>().rightSideBound.x)
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
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
            }
        }
        else
        {
            Debug.LogError("player variable is null, Script:PlayerCamera");
        }
      
    }

    public void PuzzleFocus(GameObject puzzle, float focusDuration,float extraZ)
    {
        if (!focussing)
        {
            focusPlayer = false;

            transform.position = Vector3.Lerp(transform.position, new Vector3(puzzle.transform.position.x, puzzle.transform.position.y, transform.position.z - extraZ), speed * 1000 * Time.deltaTime);

            StartCoroutine(PuzzleDisplayTime(focusDuration));
        }
    }

    private IEnumerator PuzzleDisplayTime(float i)
    {
        focussing = true;
        yield return new WaitForSeconds(i);
        focusPlayer = true;
        if (!player.GetComponent<PlayerMovement>().isActiveAndEnabled)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }
        focussing = false;
        ResetCam();
       
    }
}
