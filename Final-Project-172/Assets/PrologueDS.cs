using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueDS : MonoBehaviour
{

    public DialogueTrigger deadBody;
    public GameObject deadBodyObj;

    public DialogueTrigger narrationDialogue;

    public GameObject background;
    public GameObject lightInDarkbg;
    private bool runaway = false;
    private bool isFinished = false;
    public bool inCorout = false;

    public GameObject examineButton;
    public GameObject leaveButton;

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
        runaway = false;
        isFinished = false;
    }

    void advanceDialogue()
    {
        
        if(deadBody.completed && !runaway && !isFinished)
        {
            examineButton.SetActive(false);
            leaveButton.SetActive(false);
            lightInDarkbg.SetActive(true);
            deadBodyObj.SetActive(false);
            inCorout = true;
            StartCoroutine(DialoguePauseThenGo(narrationDialogue));
            runaway = true;
        }

        else if(deadBody.completed && runaway && !isFinished)
        {
            inCorout = true;
            StartCoroutine(DialoguePauseThenGo(narrationDialogue));
            isFinished = true;
        }
        
        else if(deadBody.completed && isFinished && runaway)
        {
            background.SetActive(true);
            lightInDarkbg.SetActive(false);
            StartCoroutine(PauseChangeScene());
        }
    }

    IEnumerator DialoguePauseThenGo(DialogueTrigger dt)
    {
        yield return new WaitForSeconds(0.5f);
        dt.TriggerDialogue();
        inCorout = false;
    }

    IEnumerator PauseChangeScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("VisualNovel");
    }
}
