using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour {
    public bool hasKey;
    public int currentLives;
    public int maxLives = 3;
    public int coins;
    public int milk;
    public int bones;
    public int textDisplayTime;
    public bool displayingText;

    public bool enteredLeft;
    public Vector3 beginingRoom;
    public GameObject currentRoom;

    public TextMeshProUGUI descriptionText;
    public TextMeshPro descriptionWorldText;
    public GameObject deadPlayer;
    public GameObject respawnParticles;
    public GameObject clickParticle;

    private UiManager uiManager;
    public float respawnTime;
    private bool dying;

    public static Animator animator;
    public GameObject DescriptionImage;

    public bool interactingFocus;

    public GameObject playerWorldUI;

    // Use this for initialization
    void Start () {

        GameObject gam = GameObject.Find("PlayerWorldUI");
        Destroy(gam);
        Instantiate(playerWorldUI, Vector3.zero, Quaternion.identity);
        animator = GetComponent<Animator>(); 
        maxLives = 3;
        currentLives = maxLives;
        beginingRoom = transform.position;
        //descriptionText = GetComponentInChildren<TextMeshProUGUI>();
        uiManager = GameObject.FindObjectOfType<UiManager>();
        respawnParticles.SetActive(false);
        clickParticle = GameObject.Find("ClickTextEffect");
        if(GameManager.gm != null)
        {
            if (GameManager.gm.currentData.finishedPath.Length != 0)
            {
                hasKey = GameManager.gm.currentData.hasKey;
                currentLives = GameManager.gm.currentData.currentLives;
                maxLives = GameManager.gm.currentData.maxLives;
                coins = GameManager.gm.currentData.coins;
                milk = GameManager.gm.currentData.milk;
                bones = GameManager.gm.currentData.bones;
            }
        }
        else
        {
            Debug.LogError("Variable GameManager.gm is null, try launching from menu, Script: Player");
        }
       
    }


    void Update()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.red);
        if(Input.GetButtonDown("Heal"))
        {
            DrinkMilk();
        }
    }

    public void CallUIUpdate()
    {
        if(uiManager != null)
        {
            uiManager.UpdateValues();
        }
        else
        {
            Debug.LogError("Variable uiManager is null, Script: Player");
        }
    }

    IEnumerator Die()
    {
        if (currentLives > 0)
        {
            dying = true;
            GameObject g = Instantiate(deadPlayer, transform.position, Quaternion.identity);

                Destroy(g, respawnTime);
                yield return new WaitForSeconds(respawnTime);
                GetComponent<Animator>().SetBool("Idle", true);
                GetComponent<Animator>().SetBool("Run", false);
                GetComponent<Animator>().SetBool("Jump", false);
        
                GetComponentInChildren<Renderer>().enabled = true;
                GetComponent<PlayerMovement>().enabled = true;
                currentLives -= 1;
                SaveTrigger.currentLivesSave -= 1;
                if (currentLives <= 0)
                {
                    if (GameManager.gm != null)
                    {
                        GameManager.gm.LoadGameState();
                    }
                    else
                    {
                        Debug.LogError("Variable GameManager.gm is null, Script: Player");
                    }
                }
                if (uiManager != null)
                {
                    uiManager.RemoveLiveUI();
                }
                else
                {
                    Debug.LogError("Variable uiManager is null, Script: Player");
                }
                PlayerCamera p = Camera.main.GetComponent<PlayerCamera>();
                if (p != null)
                {
                    p.ResetCam();
                }
                else
                {
                    Debug.LogError("Variable p (PlayerCamera) is null, add PlayerCamera to Main Camera, Script: Player");
                }
                if (enteredLeft)
                {
                    transform.position = beginingRoom + new Vector3(.4F, 0, 0);

                    respawnParticles.SetActive(true);
                    GetComponent<PlayerMovement>().enabled = false;
                    yield return new WaitForSeconds(2F);
                    GetComponent<PlayerMovement>().enabled = true;
                    respawnParticles.SetActive(false);

                    RaycastHit hit;
                    if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Vector3.down, out hit))
                    {
                        if(hit.transform.tag == "Room")
                        {
                            currentRoom = hit.transform.parent.gameObject;
                        }
                    }
                }
                else
                {
                    transform.position = beginingRoom + new Vector3(-.04F, 0, 0);

                    respawnParticles.SetActive(true);
                    GetComponent<PlayerMovement>().enabled = false;
                    yield return new WaitForSeconds(2F);
                    GetComponent<PlayerMovement>().enabled = true;
                    respawnParticles.SetActive(false);

                    RaycastHit hit;
                    if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y +1, transform.position.z), -transform.up, out hit))
                    {
                        if (hit.transform.tag == "Room")
                        {
                            currentRoom = hit.transform.parent.gameObject;
                        }
                    }
                }
                //Go reset to the bathroom or something
            }
        dying = false;
    }

    public void Death()
    {
       
        GetComponentInChildren<Renderer>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
       
        if (!dying)
        {
            StartCoroutine(Die());
        }
    }

    public void DrinkMilk()
    {
        if(milk != 0)
        {
            if(currentLives < maxLives)
            {
                uiManager.AddLiveUI();
                currentLives += 1;
                SaveTrigger.currentLivesSave += 1;
                milk -= 1;
                SaveTrigger.milkSave -=1;
                CallUIUpdate();
            }
            else
            {
                SetText("Im feeling fine",0,false);
            }
        }
        else
        {
            SetText("No sweet nectart left",0,false);
        }
    }

    public void ConsumeBone()
    {
        maxLives += 1;
        SaveTrigger.maxLivesSave += 1;
        currentLives += 1;
        SaveTrigger.currentLivesSave += 1;
        if(uiManager != null)
        {
            uiManager.AddLive();
        }
        else
        {
            Debug.LogError("Variable uiManager is null, Script: Player");
        }
    }

    public void SetText(string s, float extraTime, bool sign)
    {
        if (!displayingText)
        {
            StartCoroutine(SetPlayerDescriptionText(s, extraTime, sign));
        }
    }

    private IEnumerator SetPlayerDescriptionText(string textToShow, float extraTime, bool sign)
    {
        displayingText = true;
        if(descriptionText != null)
        {
            if (sign)
            {
                DescriptionImage.SetActive(true);
                descriptionText.text = "" + textToShow;

            }
            else
            {
                descriptionWorldText.text = "" + textToShow;
            }
        }
        else
        {
            Debug.LogError("Variable descriptionText is null, Script: Player");
        }
        yield return new WaitForSeconds(textDisplayTime + extraTime);
        if(descriptionText != null)
        {
            if (sign)
            {
                DescriptionImage.SetActive(false);
                descriptionText.text = "";

            }
            else
            {
                descriptionWorldText.text = "";
            }
        }
        else
        {
            Debug.LogError("Variable descriptionText is null, Script: Player");
        }
        displayingText = false;
        
    }

    public static void Interact(int i)
    {
        if(i == 1)
        {
           animator.SetTrigger("Interact");
           FindObjectOfType<PlayerMovement>().enabled = false;
        }

        if(i == 2)
        {
            animator.SetTrigger("Kick");
            FindObjectOfType<PlayerMovement>().enabled = false;
        }
    }
    public IEnumerator RestartMovement()
    {
        
            yield return new WaitForSeconds(1.3f);
            FindObjectOfType<PlayerMovement>().enabled = true;
            InteractableObject.interacting = false;
        }



}