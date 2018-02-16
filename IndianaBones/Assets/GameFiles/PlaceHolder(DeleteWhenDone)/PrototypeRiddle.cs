using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeRiddle : TriggerdObjects {
    public int correctAmountPressed;
    public List<GameObject> orderPressed = new List<GameObject>();
    public List<GameObject> correctOrder = new List<GameObject>();
    public int correctAmount;
    public GameObject door;

    public List<TriggerdObjects> trapsToTrigger = new List<TriggerdObjects>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerFunctionality()
    {
        if (!triggerd)
        {
            foreach(GameObject g in orderPressed)
            {
                if(orderPressed[orderPressed.IndexOf(g)].gameObject == correctOrder[correctOrder.IndexOf(g)].gameObject)
                {
                    correctAmount++;
                }
                else
                {
                    break;
                }
            }
            if(correctAmount == 3)
            {
                door.SetActive(false);
                triggerd = true;
            }
            else
            {
                foreach (TriggerdObjects t in trapsToTrigger)
                {
                    t.TriggerFunctionality();
                }
                Reset();
            }
        }

        }

    void Reset()
    {
        orderPressed.Clear();
        correctAmount = 0;
    }
}
