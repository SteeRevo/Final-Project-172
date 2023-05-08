using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSequencer : MonoBehaviour
{

    public DialogueTrigger superMarket;
    public DialogueTrigger vendingMachine;

    public DialogueTrigger nextDialogue1;
    private bool nextDiaDone = false;

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
        if(superMarket.completed && vendingMachine.completed && nextDiaDone == false)
        {
            Debug.Log("playing next dialogue");
            StartCoroutine(DialoguePauseThenGo(nextDialogue1));
            nextDiaDone = true;

            
        }
    }

    IEnumerator DialoguePauseThenGo(DialogueTrigger dt)
    {
        yield return new WaitForSeconds(0.5f);
        dt.TriggerDialogue();
    }
}
