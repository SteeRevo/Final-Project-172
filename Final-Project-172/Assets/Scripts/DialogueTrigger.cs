using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset inkJson;

    [SerializeField]
    private DialogueManager dialogueManager;

    public GameObject dialogueBox;

    public void TriggerDialogue()
    {
        if (!dialogueManager.isRunning)
        {
            dialogueBox.SetActive(true);
            dialogueManager.StartDialogue(inkJson);
        }
        
    }

    void Start()
    {
        //dialogueManager = FindObjectOfType<DialogueManager>();
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
