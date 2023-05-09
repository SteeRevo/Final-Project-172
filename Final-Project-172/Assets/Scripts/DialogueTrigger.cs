using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField]
    private DialogueManager dialogueManager;

    public GameObject dialogueBox;

    public bool autoRun = false;

    public bool completed = false;

    public List<TextAsset> dialogueList;

    private int currentDiaNum = 0;

    
   

    public void TriggerDialogue()
    {
        
        if (!dialogueManager.dialogueisRunning)
        {
            //Debug.Log(currentDiaNum);
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

    void Start()
    {
        if(autoRun)
        {
            TriggerDialogue();
        }
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
