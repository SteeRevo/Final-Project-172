using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    public GameObject vendingPuzzle;

    public void showPuzzle()
    {
        vendingPuzzle.SetActive(true);
    }
}
