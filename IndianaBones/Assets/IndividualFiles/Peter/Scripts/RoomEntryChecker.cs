using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomEntryChecker : MonoBehaviour {
    public bool left;
    public GameObject nextRoom;
    public GameObject nextPos;
    private bool changedPos;

    public float xOffset = 5;
    private GameManager gm;
    private PlayerCamera pc;
    // Use this for initialization
    void Start () 
    {
        gm = FindObjectOfType<GameManager>();
        pc = FindObjectOfType<PlayerCamera>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            pc.focusPlayer = false;
            StartCoroutine(Fade(other.gameObject));
            Player p = other.GetComponent<Player>();
            other.GetComponent<PlayerMovement>().enabled = false;
            p.currentRoom = nextRoom;


            if (p != null)
            {
                RoomBoundaryCalculator rmb = nextRoom.GetComponent<RoomBoundaryCalculator>();

                if(other.GetComponent<PlayerMovement>().x > 0)
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
                }
                else
                {
                    other.GetComponent<Player>().enteredLeft = false;
                }

            }
            else
            {
                Debug.LogError("Variable p (Player) is null, Script: RoomEntryChecker");
            }

        }

    }
    public IEnumerator Fade(GameObject player)
    {
        
        gm.fadeOut.SetActive(true);
        gm.fadeOut.GetComponent<Animator>().SetBool("FadeIn", false);
        gm.fadeOut.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitUntil(() => gm.fadeOut.GetComponent<Image>().color.a == 1);

        gm.fadeOut.GetComponent<Animator>().SetBool("FadeIn", true);
        gm.fadeOut.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitUntil(() => gm.fadeOut.GetComponent<Image>().color.a == 0);

        player.GetComponent<PlayerMovement>().enabled = true;
        pc.focusPlayer = true;

    }

}

