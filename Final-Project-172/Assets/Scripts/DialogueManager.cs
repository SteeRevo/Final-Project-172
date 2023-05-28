using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{

    private const string CHAR_TAG = "charName";
    private const string BG_TAG = "background";

    public Text nameText;
    public Text dialogueText;
    public int textSpeed = 10;
    public bool dialogueisRunning = false;
    
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject[] choices;
    [SerializeField] private string[] inkFunctionNames;
    [SerializeField] private UnityEvent[] inkEvents;
    private Text[] choicesText;
    public bool isRunning = false;

    public AudioSource textSound;
    
    

    private Story currentStory;
    private string currentSentence;
    private string charName;
    private string currentLocation;
    private bool isMakingChoice = false;

    public delegate void CompletedDialogue();
    public static event CompletedDialogue finishedDialogue;

    void Start()
    {
        choicesText = new Text[choices.Length];
        for (int i = 0; i < choices.Length; i++)
        {
            choicesText[i] = choices[i].GetComponentInChildren<Text>();
        }

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isMakingChoice)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (TextAsset inkJson)
    {
        
        dialogueisRunning = true;
        currentStory = new Story(inkJson.text);
        currentLocation = (string)currentStory.variablesState["currentLocation"];
        Debug.Log(currentLocation);

        Debug.Assert(inkFunctionNames.Length == inkEvents.Length, "inkFunctionNames and inkEvents must have same length");
        for (int i = 0; i < inkEvents.Length; i++)
        {
            int index = i;
            currentStory.BindExternalFunction(inkFunctionNames[i], () =>
            {
                inkEvents[index].Invoke();
            });
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        textSound.Stop();
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
            
            currentSentence = currentStory.Continue();
            HandleTags(currentStory.currentTags);
            nameText.text = charName;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentSentence));
            DisplayChoices();
        }
    }
    
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Too Many Choices");
        }
        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            isMakingChoice = true;
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        isMakingChoice = false;
        DisplayNextSentence();
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
                case BG_TAG:
                    Debug.Log("background=" + tagValue);
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
        textSound.Play();
        isRunning = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            float waitFrames = Time.deltaTime * textSpeed;
            yield return new WaitForSeconds(waitFrames);
        }
        isRunning = false;
        textSound.Stop();
    }

    void EndDialogue()
    {
        
        Debug.Log("End of Conversation");
        dialogueisRunning = false;
        dialogueBox.SetActive(false);
        finishedDialogue();
    }
}


/*
Things to be added:
    - character model support
    - dialogue box disappearing and appearing on start and end
    - add save and load
    - make dialoguemanager a singleton
*/