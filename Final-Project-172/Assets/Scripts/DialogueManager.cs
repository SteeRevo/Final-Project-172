using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{

    private const string CHAR_TAG = "charName";

    public Text nameText;
    public Text dialogueText;
    public int textSpeed = 100;
    public bool dialogueisRunning = false;

    private Story currentStory;
    private string currentSentence;
    private string charName;
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

    public void StartDialogue (TextAsset inkJson)
    {
        dialogueisRunning = true;
        currentStory = new Story(inkJson.text);
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
        else if (!currentStory.canContinue)
        {
            EndDialogue();
            return;
        }
        else
        {
            Debug.Log("here");
            currentSentence = currentStory.Continue();
            HandleTags(currentStory.currentTags);
            nameText.text = charName;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentSentence));
        }
    }
    
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case CHAR_TAG:
                    Debug.Log("charName=" + tagValue);
                    charName = tagValue;
                    break;
                default:
                    Debug.LogWarning("Tag cam in but is not in current scope");
                 break;
            }
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
        dialogueisRunning = false;
    }
}


/*
Things to be added:
    - character model support
    - dialogue box disappearing and appearing on start and end
    - reads from files (maybe Ink)
*/