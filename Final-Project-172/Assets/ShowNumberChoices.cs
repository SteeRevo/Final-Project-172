using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNumberChoices : MonoBehaviour
{
    public GameObject NumberPanel;

    public void ShowNumberPanel()
    {
        NumberPanel.SetActive(true);
    }
}
