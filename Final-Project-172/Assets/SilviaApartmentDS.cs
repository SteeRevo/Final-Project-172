using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilviaApartmentDS : MonoBehaviour
{
    [SerializeField]
    GameObject blackBg, outApart, inApart;
    
    [SerializeField]
    DialogueTrigger narration;

    private bool enterApartment, meetingSilvia = false;

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
        }
        else if(enterApartment && !meetingSilvia)
        {
            narration.TriggerDialogue();
        }
    }


}
