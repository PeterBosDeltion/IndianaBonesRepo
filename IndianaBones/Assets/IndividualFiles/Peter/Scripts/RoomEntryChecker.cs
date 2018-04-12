using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomEntryChecker : MonoBehaviour {
    public bool left;
    public GameObject nextRoom;
    public GameObject nextPos;
    private bool changedPos;

    public bool ladder;

    public float xOffset = 5;
    private GameManager gm;
    public PlayerCamera pc;

    private bool running;
    private bool colliding; 

    // Use this for initialization
    void Start () 
    {
        gm = FindObjectOfType<GameManager>();
        pc = FindObjectOfType<PlayerCamera>();
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            colliding = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!ladder)
        {
            ChangeRoom(other);
        }
        else
        {
            if (Input.GetButtonDown("E"))
            {
                ChangeRoom(other);
            }
        }
       

    }

    public void ChangeRoom(Collider other)
    {
        colliding = true;
        if (other.tag == "Player" && colliding)
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
            other.GetComponent<PlayerMovement>().enabled = false;
            pc.focusPlayer = false;
            if (!running)
            {
                StartCoroutine(Fade(other.gameObject));
            }
            
        }
    }

    private void ChangeRoomTwo(Collider other)
    {
        Player p = other.GetComponent<Player>();
        p.currentRoom = nextRoom;


        if (p != null)
        {
            //RoomBoundaryCalculator rmb = nextRoom.GetComponent<RoomBoundaryCalculator>();

            if (other.GetComponent<PlayerMovement>().x > 0)
            {
                other.transform.position = new Vector3(nextPos.transform.position.x, nextPos.transform.position.y, other.transform.position.z);
            }
            else
            {
                other.transform.position = new Vector3(nextPos.transform.position.x, nextPos.transform.position.y, other.transform.position.z);
            }
            if (left)
            {
                other.GetComponent<Player>().enteredLeft = true;
                p.beginingRoom = new Vector3(nextRoom.GetComponent<RoomBoundaryCalculator>().leftSideBound.x + .4F, other.transform.position.y, other.transform.position.z);

            }
            else
            {
                other.GetComponent<Player>().enteredLeft = false;
                p.beginingRoom = new Vector3(nextRoom.GetComponent<RoomBoundaryCalculator>().rightSideBound.x - .4F, other.transform.position.y, other.transform.position.z);
            }

        }
        else
        {
            Debug.LogError("Variable p (Player) is null, Script: RoomEntryChecker");
        }

    }

    public IEnumerator Fade(GameObject p)
    {

        running = true;
        if (running)
        {
            gm.fadeOut.GetComponent<Animator>().speed = 5F;
            p.GetComponent<PlayerMovement>().x = 0;

            gm.fadeOut.SetActive(true);
            gm.fadeOut.GetComponent<Animator>().SetBool("FadeIn", false);
            gm.fadeOut.GetComponent<Animator>().SetTrigger("Fade");
            p.GetComponent<Animator>().SetBool("Run", false);
            p.GetComponent<Animator>().SetBool("Jump", false);
            p.GetComponent<Animator>().SetBool("Idle", true);

            yield return new WaitUntil(() => gm.fadeOut.GetComponent<Image>().color.a == 1);


            ChangeRoomTwo(p.GetComponent<Collider>());//Wait until screen is black and then complete function
            pc.ResetCam();


            gm.fadeOut.GetComponent<Animator>().SetBool("FadeIn", true);
            gm.fadeOut.GetComponent<Animator>().SetTrigger("Fade");

            yield return new WaitUntil(() => gm.fadeOut.GetComponent<Image>().color.a <= 0);
            gm.fadeOut.SetActive(false);


            p.GetComponent<PlayerMovement>().enabled = true;
            pc.focusPlayer = true;

            running = false;

        }

    }

}

