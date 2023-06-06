using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenSearchDS : MonoBehaviour
{
    [SerializeField]
    GameObject blackBg, silvia_idle, silvia_sad;
    
    [SerializeField]
    DialogueTrigger narration;

    //[SerializeField]
    //Button cooper;

    [SerializeField]
    ShowTriggers returnExamine;

    enum GameState {wakingUp, cooperTalk, cheerUp, explore};

    //private bool wakingUp, cooperTalk,  cheerUp = false;

    private GameState currentState = GameState.wakingUp;

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
        if(currentState == GameState.wakingUp){
            currentState = GameState.cooperTalk;
            blackBg.SetActive(false);
            narration.TriggerDialogue();
        }
        else if(currentState == GameState.cooperTalk){
            silvia_idle.SetActive(true);
            silvia_sad.SetActive(false);
            currentState = GameState.cheerUp;
            narration.TriggerDialogue();
        }
        else if(currentState == GameState.cheerUp)
        {
            
            currentState = GameState.explore;
        }
    }
}
