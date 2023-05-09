using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSequencer : MonoBehaviour
{

    public DialogueTrigger superMarket;
    public DialogueTrigger vendingMachine;

    public DialogueTrigger nextDialogue1;
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
        if(superMarket.completed && vendingMachine.completed && !nextDiaDone)
        {
            StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDiaDone = true;

            
        }
        else if(nextDiaDone && !nextDiaDone1)
        {
            background.SetActive(false);
            StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDiaDone1 = true;
        }

        else if(nextDiaDone1 && !isFinished)
        {
           background.SetActive(true);
           //StarCoroutine(DialoguePauseThenGo(nextDialogue1))
        }

        
    }



    IEnumerator DialoguePauseThenGo(DialogueTrigger dt)
    {
        yield return new WaitForSeconds(0.5f);
        dt.TriggerDialogue();
    }
}
