using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationChanger : MonoBehaviour
{
    public string location;

    [SerializeField]
    private DialogueManager dialogueManager;
    
    public void locationChanger(string location)
    {
        if(!dialogueManager.dialogueisRunning)
        {
            switch(location)
            {
                case "Apartment":
                    SceneManager.LoadScene("Apartment");
                    break;
                default:
                    Debug.Log("No location found");
                    break;
            }
        }
        
    }
}
