using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSequencer : MonoBehaviour
{

    public DialogueTrigger superMarket;
    public GameObject superMarketObj;
    public DialogueTrigger vendingMachine;
    public GameObject vendingObj;
    public Button Nicholas;

    public GameObject vendingPuzzle1;
    public GameObject vendingPuzzle2;
    public GameObject NicholasPuzzle;
    public GameObject NicholasPuzzlePanel;


    public DialogueTrigger nextDialogue1;
    private bool introDialogue = false;
    private bool nextDiaDone = false;
    private bool nextDiaDone1 = false;
    private bool nextDiaDone2 = false;
    private bool isFinished = false;
    public bool inCorout = false;
    private bool inPuzzle = false;
    private bool gotCorrectAnswer = false;
    private bool solvedPuzzle = false;

    public GameObject background;

    public delegate void InCoroutine();
    public static event InCoroutine DisableClick;
    public static event InCoroutine EnableClick;
    

    void OnEnable()
    {
        DialogueManager.finishedDialogue += advanceDialogue1;
        PuzzleAnswer.correctAnswer += advanceAnswer;
    }

    void OnDisable()
    {
        DialogueManager.finishedDialogue -= advanceDialogue1;
        PuzzleAnswer.correctAnswer -= advanceAnswer;
    }

    void Start()
    {
        introDialogue = false;
        nextDiaDone = false;
        nextDiaDone1 = false;
        nextDiaDone2 = false;
        isFinished = false;
        inPuzzle = false;
        solvedPuzzle = false;

    }

    void advanceAnswer()
    {
        gotCorrectAnswer = true;
        advanceDialogue1();
    }

    public void advanceDialogue1()
    {
        if(!introDialogue)
        {
            background.SetActive(false);
            introDialogue = true;
            nextDialogue1.TriggerDialogue();
        }

        //after examining supermarket
        else if(superMarket.completed && vendingMachine.completed && !nextDiaDone)
        {
            inCorout = true;
            //StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDialogue1.TriggerDialogue();
            nextDiaDone = true;
            superMarketObj.SetActive(false);
            vendingObj.SetActive(false);
            Nicholas.enabled = false;


            
        }
        //turning to face the darkness
        else if(nextDiaDone && !nextDiaDone1)
        {
            inCorout = true;
            background.SetActive(true);
            //StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDialogue1.TriggerDialogue();
            nextDiaDone1 = true;
        }

        //going back to the supermarket
        else if(nextDiaDone1 && !isFinished)
        {
            inCorout = true;
            background.SetActive(false);
            //StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDialogue1.TriggerDialogue();
            isFinished = true;
            
        }
        else if(isFinished && !inPuzzle && !solvedPuzzle)
        {
            vendingPuzzle1.SetActive(true);
            vendingPuzzle2.SetActive(true);
            NicholasPuzzle.SetActive(true);
            inPuzzle = true;
        }

        else if(inPuzzle && gotCorrectAnswer && !solvedPuzzle)
        {
            Debug.Log("Way to go");
            //StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDialogue1.TriggerDialogue();
            solvedPuzzle = true;
            inPuzzle = false;
            NicholasPuzzlePanel.SetActive(false);

        }
        else if(!inPuzzle && solvedPuzzle)
        {
            SceneManager.LoadScene(7);
        }

        
    }



    /*IEnumerator DialoguePauseThenGo(DialogueTrigger dt)
    {
        yield return new WaitForSeconds(0.5f);
        dt.TriggerDialogue();
        inCorout = false;
    }*/
}
