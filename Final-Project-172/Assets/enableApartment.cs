using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableApartment : MonoBehaviour
{

    public GameObject apartmentButton;
    void OnEnable()
    {
        examineItem.walletChecked += enableButton;
    }

    void OnDisable()
    {
        examineItem.walletChecked -= enableButton;
    }

    private void enableButton()
    {
        apartmentButton.SetActive(true);
    }
}
