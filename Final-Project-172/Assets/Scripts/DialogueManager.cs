using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public int textSpeed = 100;

    private string currentSentence;
    private bool isRunning = false;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (isRunning)
        {
            StopAllCoroutines();
            dialogueText.text = currentSentence;
            isRunning = false;
        }
        else if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            currentSentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentSentence));
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        isRunning = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            float waitFrames = Time.deltaTime * textSpeed;
            yield return new WaitForSeconds(waitFrames);
        }
        isRunning = false;
    }

    void EndDialogue()
    {
        Debug.Log("End of Conversation");
    }

}
