using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitExamine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject examinePanel;

    public void exitExamination()
    {
        examinePanel.SetActive(false);
    }
}
