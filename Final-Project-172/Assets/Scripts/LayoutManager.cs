using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutManager : MonoBehaviour
{

    private const string INSTANTIATE_OP = "INSTANTIATE";
    private const string DELETE_OP = "DELETE";
    private const string TRANSLATE_OP = "TRANSLATE";

    // could we make a json to store this data, paths to backgrounds, as well as clickable item sprites, locations, and ink files?
    private string[] charNames = {"Nicholas", "Cooper", "Silvia"};
    [SerializeField] private Texture2D[] charSprites;

    public Image background;
    public Sprite superMarket;

    public void changeBackground(string backgroundName) 
    {
        switch(backgroundName)
        {
            case "distortedSupermarket":
                background.sprite = superMarket;
                break;
            default:
                Debug.Log("could not change background");
                break;
        }
    }

    public void operateCharacter(KeyValuePair<string, string[]> operation)
    {
        Debug.Log("operationStart");
        foreach (string s in operation.Value)
        {
            switch (s)
            {
                case INSTANTIATE_OP:
                    Debug.Log("enter Instantiation");
                    break;
                case DELETE_OP:
                    Debug.Log("enter Deletion");
                    break;
                case TRANSLATE_OP:
                    Debug.Log("enter Translation");
                    break;
                default:
                    Debug.LogWarning("Operation is not in current scope");
                    break;
            }
        }
        return;
    }
}
