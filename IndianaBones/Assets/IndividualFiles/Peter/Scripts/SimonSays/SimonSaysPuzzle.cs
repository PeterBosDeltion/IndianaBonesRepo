using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysPuzzle : Puzzle {
    public List<GameObject> correctOrder = new List<GameObject>();
    public List<GameObject> insertedOrder = new List<GameObject>();
    private List<GameObject> finalOrder = new List<GameObject>();

    public List<TriggerdObjects> trapsToTriggerOnLose = new List<TriggerdObjects>();

    private bool showingOrder;
    public float lightUpTime;

    private int correctAmount;
    public bool done;

    public List<TriggerdObjects> toTriggerOnWin = new List<TriggerdObjects>();

    private int intyMcIntface;
	// Use this for initialization
	void Start () {
        puzzleManager = FindObjectOfType<PuzzleManager>();
	}
	
	// Update is called once per frame
	void Update () {
            //Debug.Log(intyMcIntface);

    }

    public IEnumerator ShowOrder()
    {
        if (!showingOrder)
        {
            showingOrder = true;
            foreach (GameObject g in correctOrder)
            {
                //Make bool to not have lots of thingies
                yield return new WaitForSeconds(lightUpTime);
                SayButton sb = g.GetComponent<SayButton>();
                sb.StartCoroutine(sb.LightUp(lightUpTime));

            }
            showingOrder = false;
        }
       
    }

    //public void EnterButton(GameObject button)
    //{
    //    insertedOrder.Add(button);
    //}

    //public void CheckOrder()
    //{
    //    int w = new int();

    //    bool incorrect = new bool();
    //    foreach (GameObject g in insertedOrder)
    //    {
    //        //if (correctOrder.Contains(g))
    //        //{
    //            for (int i = 0; i < correctOrder.Count; i++)
    //            {
    //                if (insertedOrder[i] == correctOrder[i])
    //                {
    //                    Debug.Log("Correct");
    //                    finalOrder.Add(insertedOrder[i]);
    //                    for (int q = 0; q < correctOrder.Count; q++)
    //                    {
    //                        if(finalOrder[i] == correctOrder[i])
    //                        {
    //                            w++;
    //                            if(w == correctOrder.Count)
    //                            {
    //                                Winner();
    //                            }
    //                        }
    //                    }
    //                    //if (correctAmount < correctOrder.Count)
    //                    //{
    //                    //    correctAmount++;
    //                    //}
    //                    Debug.Log(correctAmount);
    //                }
    //                else
    //                {
    //                    incorrect = true;
    //                    break;

    //                }
    //            }
    //        //}

           
    //    }

    //    if (incorrect)
    //    {
    //        IncorrectAnswer();
    //    }


    //}

    //public void Winner()
    //{
    //    foreach (TriggerdObjects t in toTriggerOnWin)
    //    {
    //        t.TriggerFunctionality();
    //    }
    //    done = true;
    //}

    //void IncorrectAnswer()
    //{
    //    Debug.Log("Incorrect");
    //    insertedOrder.Clear();
    //    finalOrder.Clear();
    //    correctAmount = 0;
    //    Debug.Log(correctAmount);

    //    foreach (TriggerdObjects t in trapsToTriggerOnLose)
    //    {
    //        t.TriggerFunctionality();
    //    }
    //}

    public override void PuzzleTrigger(TriggerdObjects currentObject)
    {
        if (!done)
        {
            if(correctOrder[intyMcIntface] == currentObject.gameObject)
            {
                intyMcIntface++;
            }
            else
            {
                foreach (TriggerdObjects t in trapsToTriggerOnLose)
                {
                    t.TriggerFunctionality();
                }
                intyMcIntface = 0;
            }


            if(intyMcIntface == correctOrder.Count)
            {
                puzzleManager.done = true;
                done = true;
                //foreach (TriggerdObjects t in toTriggerOnWin)
                //{
                //    t.TriggerFunctionality();
                //}
            }

        }
        //IsDone();

    }



}
