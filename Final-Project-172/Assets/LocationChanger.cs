using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationChanger : MonoBehaviour
{
    public string location;
    
    public void locationChanger(string location)
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
