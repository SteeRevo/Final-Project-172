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
            lightInDarkbg.SetActive(true);
            deadBodyObj.SetActive(false);
            StartCoroutine(DialoguePauseThenGo(narrationDialogue));
            runaway = true;
        }

        else if(deadBody.completed && runaway && !isFinished)
        {
           
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
    }

    IEnumerator PauseChangeScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("VisualNovel");
    }
}
