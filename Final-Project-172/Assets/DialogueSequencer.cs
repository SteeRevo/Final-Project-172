using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    public DialogueTrigger nextDialogue1;
    private bool introDialogue = false;
    private bool nextDiaDone = false;
    private bool nextDiaDone1 = false;
    private bool nextDiaDone2 = false;
    private bool isFinished = false;
    public bool inCorout = false;

    public GameObject background;

    public delegate void InCoroutine();
    public static event InCoroutine DisableClick;
    

    void OnEnable()
    {
        DialogueManager.finishedDialogue += advanceDialogue1;
    }

    void OnDisable()
    {
        DialogueManager.finishedDialogue -= advanceDialogue1;
    }

    void Start()
    {
        introDialogue = false;
        nextDiaDone = false;
        nextDiaDone1 = false;
        nextDiaDone2 = false;
        isFinished = false;
    }

    void advanceDialogue1()
    {
        if(!introDialogue)
        {
            background.SetActive(false);
            introDialogue = true;
            StartCoroutine(DialoguePauseThenGo(nextDialogue1));
        }

        //after examining supermarket
        else if(superMarket.completed && vendingMachine.completed && !nextDiaDone)
        {
            inCorout = true;
            StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDiaDone = true;
            superMarketObj.SetActive(false);
            vendingObj.SetActive(false);
            vendingPuzzle1.SetActive(true);
            vendingPuzzle2.SetActive(true);
            NicholasPuzzle.SetActive(true);
            Nicholas.enabled = false;


            
        }
        //turning to face the darkness
        else if(nextDiaDone && !nextDiaDone1)
        {
            inCorout = true;
            background.SetActive(true);
            StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDiaDone1 = true;
        }

        //going back to the supermarket
        else if(nextDiaDone1 && !isFinished)
        {
            inCorout = true;
            background.SetActive(false);
            StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            isFinished = true;
        }

        
    }



    IEnumerator DialoguePauseThenGo(DialogueTrigger dt)
    {
        yield return new WaitForSeconds(0.5f);
        dt.TriggerDialogue();
        inCorout = false;
    }
}
