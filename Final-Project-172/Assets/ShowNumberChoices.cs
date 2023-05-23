using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNumberChoices : MonoBehaviour
{
    public GameObject NumberPanel;
    public GameObject vendingMachineExamine1;
    public GameObject vendingMachineExamine2;

    public void ShowNumberPanel()
    {
        NumberPanel.SetActive(true);
        vendingMachineExamine1.SetActive(false);
        vendingMachineExamine2.SetActive(false);

    }
}
