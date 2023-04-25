using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset inkJson;

    private DialogueManager dialogueManager;

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(inkJson);
    }

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !dialogueManager.dialogueisRunning)
        {
            Debug.Log("Pressed primary button.");
            TriggerDialogue();
        }
    }
}
