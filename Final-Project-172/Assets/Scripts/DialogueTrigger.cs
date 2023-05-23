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



    public void TriggerDialogue()
    {
        
        if (!dialogueManager.dialogueisRunning)
        {
            Debug.Log(currentDiaNum);
            dialogueBox.SetActive(true);
            dialogueManager.StartDialogue(dialogueList[currentDiaNum]);
            completed = true;
            if(currentDiaNum < (dialogueList.Count - 1)){
                currentDiaNum += 1;
                
            }
        }
        else
        {
            Debug.Log("in dialogue right now");
        }
        
    }

    void Awake()
    {
        currentDiaNum = 0;
        if(autoRun)
        {
            TriggerDialogue();
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
