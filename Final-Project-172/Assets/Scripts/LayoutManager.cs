using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutManager : MonoBehaviour
{

    private const string INSTANTIATE_OP = "INSTANTIATE";
    private const string DELETE_OP = "DELETE";
    private const string TRANSLATE_OP = "TRANSLATE";

    private IDictionary<string, GameObject> charDictionary = new Dictionary<string, GameObject>();
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
        string op;
        string dir;
        foreach (string s in operation.Value)
        {
            if (s.Contains("LEFT"))
            {
                op = TRANSLATE_OP;
                dir = "LEFT";
            }
            else if (s.Contains("RIGHT"))
            {
                op = TRANSLATE_OP;
                dir = "RIGHT";
            }
            else if (s.Contains("CENTER"))
            {
                op = TRANSLATE_OP;
                dir = "CENTER";
            }
            else
            {
                op = s.Trim();
                dir = "";
            }
            switch (op)
            {
                case INSTANTIATE_OP:
                    Debug.Log("enter Instantiation");
                    if (charDictionary.ContainsKey(operation.Key.Trim()))
                    {  
                        break;
                    }
                    GameObject imgObject = new GameObject(operation.Key);

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
                    charDictionary.Add(operation.Key.Trim(), imgObject);
                    break;
                case DELETE_OP:
                    Debug.Log("enter Deletion");
                    break;
                case TRANSLATE_OP:
                    Debug.Log("enter Translation");
                    Debug.Log(op);
                    Debug.Log(dir);
                    RectTransform charTrans;
                    if (charDictionary.ContainsKey(operation.Key.Trim()))
                    {  
                        charTrans = charDictionary[operation.Key.Trim()].GetComponent<RectTransform>();
                    }
                    else
                    {
                        break; 
                    }
                    switch(dir)
                    {
                        case("LEFT"):
                            Debug.Log("LEFT");
                            charTrans.anchoredPosition = new Vector2(-250f, -65f);
                            break;
                        case("CENTER"):
                            Debug.Log("CENTER");
                            charTrans.anchoredPosition = new Vector2(0f, -65f);
                            break;
                        case("RIGHT"):
                            Debug.Log("RIGHT");
                            charTrans.anchoredPosition = new Vector2(250f, -65f);
                            break;
                        default:
                            Debug.LogWarning("Translation Direction is not in current scope");
                            break;
                    }
                    break;
                default:
                    Debug.LogWarning("Operation is not in current scope");
                    break;
            }
        }
        return;
    }
}
