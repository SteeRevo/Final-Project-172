using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitExamine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject examinePanel;
    public GameObject vendingMachinePuzzle1;
    public GameObject vendingMachinePuzzle2;

    public void exitExamination()
    {
        examinePanel.SetActive(false);
        vendingMachinePuzzle1.SetActive(true);
        vendingMachinePuzzle2.SetActive(true);
        
    }
}
