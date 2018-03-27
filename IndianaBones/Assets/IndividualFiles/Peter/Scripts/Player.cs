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
    private bool displayingText;

    public bool enteredLeft;
    public Vector3 beginingRoom;
    public GameObject currentRoom;

    public TextMeshProUGUI descriptionText;
    public GameObject deadPlayer;

    private UiManager uiManager;
    public float respawnTime;
    private bool dying;
    // Use this for initialization
    void Start () {
        currentLives = maxLives;
        beginingRoom = transform.position;
        //descriptionText = GetComponentInChildren<TextMeshProUGUI>();
        uiManager = GameObject.FindObjectOfType<UiManager>();

        if(GameManager.gm != null)
        {
            if (GameManager.gm.currentData != null)
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
        dying = true;
        GameObject g = Instantiate(deadPlayer, transform.position, Quaternion.identity);

        Destroy(g, respawnTime);
        yield return new WaitForSeconds(respawnTime);
        if (currentLives > 0)
        {
            GetComponentInChildren<Renderer>().enabled = true;
            GetComponent<PlayerMovement>().enabled = true;
            currentLives -= 1;
            SaveTrigger.currentLivesSave -= 1;
            if (uiManager != null)
            {
                uiManager.UpdateValues();
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
                transform.position = beginingRoom + new Vector3(2, 0, 0);
                RaycastHit hit;
                if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Vector3.down, out hit))
                {
                    if(hit.transform.tag == "Room")
                    {
                        Debug.Log("Ray hit");
                        currentRoom = hit.transform.parent.gameObject;
                    }
                }
            }
            else
            {
                transform.position = beginingRoom + new Vector3(-2, 0, 0);
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y +1, transform.position.z), -transform.up, out hit))
                {
                    if (hit.transform.tag == "Room")
                    {
                        Debug.Log("Ray hit");
                        currentRoom = hit.transform.parent.gameObject;
                    }
                }
            }
            //Go reset to the bathroom or something
        }
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
        if(currentLives < maxLives)
        {
            currentLives += 1;
            SaveTrigger.currentLivesSave += 1;
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

    public void SetText(string s, float extraTime)
    {
        if (!displayingText)
        {
            StartCoroutine(SetPlayerDescriptionText(s, extraTime));
            
        }
    }

    private IEnumerator SetPlayerDescriptionText(string textToShow, float extraTime)
    {
        displayingText = true;
        if(descriptionText != null)
        {
            descriptionText.text = "" + textToShow;
        }
        else
        {
            Debug.LogError("Variable descriptionText is null, Script: Player");
        }
        yield return new WaitForSeconds(textDisplayTime + extraTime);
        if(descriptionText != null)
        {
            descriptionText.text = "";
        }
        else
        {
            Debug.LogError("Variable descriptionText is null, Script: Player");
        }
        displayingText = false;
    }
}
