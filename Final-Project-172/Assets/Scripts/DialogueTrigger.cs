using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField]
    private DialogueManager dialogueManager;

    public GameObject dialogueBox;

    public bool autoRun = false;

    public bool completed = false;

    public List<TextAsset> dialogueList;

    private int currentDiaNum = 0;

    public DialogueSequencer ds;

    public bool destroyAfter;
    public bool disableScriptAfter;

    public FollowMouse cursorText;

    public SetCustomCursor setcursor;



    public void TriggerDialogue()
    {
        
        if (!dialogueManager.dialogueisRunning)
        {
            Debug.Log("currentDiaNum " + currentDiaNum);
            Debug.Log("dialouge count " + (dialogueList.Count - 1));
            dialogueBox.SetActive(true);
            dialogueManager.StartDialogue(dialogueList[currentDiaNum]);
            completed = true;
            if(currentDiaNum == (dialogueList.Count - 1) && destroyAfter)
            {
                setcursor.DefaultCursor();
                Debug.Log("Destroy this");
                gameObject.SetActive(false);
            }
            if(currentDiaNum == (dialogueList.Count - 1) && disableScriptAfter)
            {
                //setcursor.DefaultCursor();
                Debug.Log("Destroy this");
                enabled = false;
                //gameObject.SetActive(false);
            }
            else if(currentDiaNum < (dialogueList.Count - 1)){
                currentDiaNum += 1;
                
            }
            
        }
        else
        {
            Debug.Log("in dialogue right now");
        }
        
    }

    public IEnumerator DialoguePauseThenGo()
    {
        yield return new WaitForSeconds(0.5f);
        TriggerDialogue();
    }

    void Awake()
    {
        currentDiaNum = 0;
        if(autoRun)
        {
            StartCoroutine(DialoguePauseThenGo());
        }
        
    }

    void Start()
    {
        
        
    }

    public void setDialogueNum(int n)
    {
        currentDiaNum = n;
    }

    /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !dialogueManager.dialogueisRunning)
        {
            
            Debug.Log("Pressed primary button.");
            TriggerDialogue();
        }
    }
    */
}
