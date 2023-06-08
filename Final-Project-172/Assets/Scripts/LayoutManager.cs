using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutManager : MonoBehaviour
{

    private const string INSTANTIATE_OP = "INSTANTIATE";
    private const string DELETE_OP = "DELETE";
    private const string TRANSLATE_OP = "TRANSLATE";

    private IDictionary<string, Image> charDictionary = new Dictionary<string, Image>();
    // could we make a json to store this data, paths to backgrounds, as well as clickable item sprites, locations, and ink files?

    public Image background;
    public Sprite superMarket;
    public GameObject canvas;
    public GameObject characterCanvas;

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
        foreach (string s in operation.Value)
        {
            switch (s.Trim())
            {
                case INSTANTIATE_OP:
                    Debug.Log("enter Instantiation");
                    GameObject imgObject = new GameObject("testAAA");

                    RectTransform trans = imgObject.AddComponent<RectTransform>();
                    trans.transform.SetParent(characterCanvas.transform); // setting parent
                    trans.localScale = Vector3.one;
                    trans.anchoredPosition = new Vector2(0f, -65f); // setting position, will be on center
                    trans.sizeDelta= new Vector2(205, 590); // custom size

                    Image image = imgObject.AddComponent<Image>();
                    Texture2D charTexture = Resources.Load<Texture2D>("Characters/" + operation.Key.Trim());
                    Debug.Log("Characters/" + operation.Key);
                    Debug.Log(charTexture);
                    image.sprite = Sprite.Create(charTexture, new Rect(0, 0, charTexture.width, charTexture.height), new Vector2(0.5f, 0.5f));
                    imgObject.transform.SetParent(characterCanvas.transform);
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
