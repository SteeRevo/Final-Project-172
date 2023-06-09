using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SilviaApartmentDS : MonoBehaviour
{
    [SerializeField]
    GameObject blackBg, outApart, inApart, examineButton, talkButton, cooperImgMiddle, cooperImgSide, silviaImg, nameChoice;
    
    [SerializeField]
    DialogueTrigger narration, bookshelf1, bookshelf2, plant, painting, nicholasName, silviaName;

    [SerializeField]
    Button cooper;

    [SerializeField]
    ShowTriggers returnExamine;

    private bool enterApartment, foundSilvia, meetingSilvia, guessingName, makingChoice, goingToBed = false;

    void OnEnable()
    {
        DialogueManager.finishedDialogue += sequence;
        
    }

    void OnDisable()
    {
        DialogueManager.finishedDialogue -= sequence;
    }

    void sequence()
    {
        if(!enterApartment){
            enterApartment = true;
            blackBg.SetActive(false);
            narration.TriggerDialogue();
        }
        else if(enterApartment && !meetingSilvia)
        {
            examineButton.SetActive(true);
            talkButton.SetActive(true);
            meetingSilvia = true;
        }
        else if(meetingSilvia && painting.completed && (bookshelf1.completed || bookshelf2.completed) && plant.completed && !foundSilvia){
            //Debug.Log("Found silvia");
            foundSilvia = true;
            returnExamine.deactivateTriggers();
            narration.TriggerDialogue();
        }
        else if(foundSilvia && !guessingName)
        {
            cooperImgSide.SetActive(true);
            silviaImg.SetActive(true);
            Debug.Log("what's her name?");
            guessingName = true;
            narration.TriggerDialogue();
        }
        else if(guessingName && !makingChoice){
            nameChoice.SetActive(true);
            makingChoice = true;
        }
        else if(makingChoice && !goingToBed && (nicholasName.completed || silviaName.completed))
        {
            nameChoice.SetActive(false);
            goingToBed = true;
            narration.TriggerDialogue();
            
        }
        else if(goingToBed)
        {
            blackBg.SetActive(true);
            SceneManager.LoadScene("TheOpenSearch");
        }

    }


}
