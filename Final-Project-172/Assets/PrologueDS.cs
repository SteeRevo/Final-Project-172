using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueDS : MonoBehaviour
{

    public DialogueTrigger deadBodyhead;
    public DialogueTrigger deadBody;
    public DialogueTrigger deadBodylegs;
    public GameObject deadBodyObj;

    public DialogueTrigger narrationDialogue;
    public DialogueTrigger runawayDialogue;

    public GameObject background;
    public GameObject lightInDarkbg;
    public bool runaway = false;
    private bool isFinished = false;
    public bool inCorout = false;

    private bool p1 = false;

    public GameObject examineButton;
    public GameObject leaveButton;

    private bool choseExamine = false;

    void OnEnable()
    {
        DialogueManager.finishedDialogue += advanceDialogue;
    }

    void OnDisable()
    {
        DialogueManager.finishedDialogue -= advanceDialogue;
    }

    void Start()
    {
        p1 = false;
        runaway = false;
        isFinished = false;
    }

    void advanceDialogue()
    {
        if(!p1)
        {
            examineButton.SetActive(true);
            leaveButton.SetActive(true);
            p1 = true;
        }


        
        else if(deadBodyhead.completed && deadBodylegs.completed && deadBody.completed && !choseExamine)
        {
            examineButton.SetActive(false);
            leaveButton.SetActive(false);
            //lightInDarkbg.SetActive(true);
            deadBodyObj.SetActive(false);
            
            narrationDialogue.setDialogueNum(3);
            narrationDialogue.TriggerDialogue();
            choseExamine = true;
        }

        else if(choseExamine)
        {
            background.SetActive(true);
            StartCoroutine(PauseChangeScene());
        }

        else if(runaway && !isFinished)
        {
            lightInDarkbg.SetActive(true);
            runawayDialogue.TriggerDialogue();
            isFinished = true;
        }
        
        else if(isFinished && runaway)
        {
            background.SetActive(true);
            StartCoroutine(PauseChangeScene());
        }
    }

    IEnumerator PauseChangeScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("VisualNovel");
    }
}
