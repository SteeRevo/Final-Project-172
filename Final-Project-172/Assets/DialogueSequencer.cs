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

    public GameObject vendingPuzzle;

    public DialogueTrigger nextDialogue1;
    private bool introDialogue = false;
    private bool nextDiaDone = false;
    private bool nextDiaDone1 = false;
    private bool nextDiaDone2 = false;
    private bool isFinished = false;

    public GameObject background;
    

    void OnEnable()
    {
        DialogueManager.finishedDialogue += advanceDialogue1;
    }

    void OnDisable()
    {
        DialogueManager.finishedDialogue -= advanceDialogue1;
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
            StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDiaDone = true;
            superMarketObj.SetActive(false);
            vendingObj.SetActive(false);
            vendingPuzzle.SetActive(true);


            
        }
        //turning to face the darkness
        else if(nextDiaDone && !nextDiaDone1)
        {
            background.SetActive(true);
            StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDiaDone1 = true;
        }

        //going back to the supermarket
        else if(nextDiaDone1 && !isFinished)
        {
           background.SetActive(false);
           StartCoroutine(DialoguePauseThenGo(nextDialogue1));
           isFinished = true;
        }

        
    }



    IEnumerator DialoguePauseThenGo(DialogueTrigger dt)
    {
        yield return new WaitForSeconds(0.5f);
        dt.TriggerDialogue();
    }
}
