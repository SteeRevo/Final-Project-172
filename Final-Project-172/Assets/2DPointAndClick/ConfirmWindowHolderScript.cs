using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmWindowHolderScript : MonoBehaviour
{
    [SerializeField] 
    private ConfirmationWindowScript confirmationWindow;
    // Start is called before the first frame update
    void Start()
    {
        OpenConfirmationWindow("You just opened a book");
    }

    private void OpenConfirmationWindow(string message) {
        confirmationWindow.gameObject.SetActive(true);
        confirmationWindow.yesButton.onClick.AddListener(YesClicked);
        confirmationWindow.noButton.onClick.AddListener(NoClicked);
        confirmationWindow.messageText.text = message;
    }

    private void YesClicked() {
        confirmationWindow.gameObject.SetActive(false);
        Debug.Log("Yes Clicked");
    }

    private void NoClicked() {
        confirmationWindow.gameObject.SetActive(false);
        Debug.Log("No clicked");
    }

}
