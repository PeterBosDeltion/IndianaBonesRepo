using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TriviaPuzzle : Puzzle {

    public string winText = "Access granted";

    [TextArea(15, 3)]
    public List<string> questions = new List<string>();
    [TextArea(15, 3)]
    public List<string> answers = new List<string>();
    [TextArea(15, 3)]
    public List<string> fakeAnswers = new List<string>();

    public List<TriviaButton> answerButtons = new List<TriviaButton>();
    public int correctAnswers;

    private int currentQuestion = -1;

    public TextMeshPro questionText;

    public List<TriggerdObjects> trapsOnLose = new List<TriggerdObjects>();
    // Use this for initialization
    void Start () {
        puzzleManager = FindObjectOfType<PuzzleManager>();
        NextQuestion();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public override void PuzzleTrigger(TriggerdObjects currentObject)
    {
        Debug.Log("Triggered puzzle");
        //If currentobject is correct
        if (currentObject.gameObject.GetComponent<TriviaButton>().correct)
        {
            correctAnswers++;
            if(correctAnswers < questions.Count)
            {
                NextQuestion();
            }

            else if (correctAnswers == questions.Count)
            {
                //winner
                Debug.Log("U won");
                puzzleManager.done = true;
                questionText.text = winText;

                //Trigger the things on win
            }
        }
        else //U ded cuz traps
        {
            Debug.Log("Loser scrub git gut");
            foreach (TriggerdObjects t in trapsOnLose)
            {
                t.TriggerFunctionality();
            }

            correctAnswers = 0;
            currentQuestion = -1;

            NextQuestion();
        }
    }

    public void NextQuestion()
    {
        currentQuestion++;
        questionText.text = questions[currentQuestion];
        int i = Random.Range(0, answerButtons.Count);
        answerButtons[i].GetComponent<ObjectDescriptor>().descriptions.Clear();
        answerButtons[i].GetComponent<ObjectDescriptor>().descriptions.Add(answers[currentQuestion]);
        answerButtons[i].correct = true;

        foreach (TriviaButton t in answerButtons)
        {
            if(t != answerButtons[i])
            {
                string s = fakeAnswers[Random.Range(0, fakeAnswers.Count)];
                t.GetComponent<ObjectDescriptor>().descriptions.Clear();
                t.GetComponent<ObjectDescriptor>().descriptions.Add(s);

            }
        }




    }
}
