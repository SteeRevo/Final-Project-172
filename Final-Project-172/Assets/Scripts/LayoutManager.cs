using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutManager : MonoBehaviour
{
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
        return;
    }
}
