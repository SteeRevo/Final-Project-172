using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnswer : MonoBehaviour
{

    public delegate void PuzzleEvent();
    public static event PuzzleEvent correctAnswer;

    public void onCorrectAnswer()
    {
        Debug.Log("correct answer");
        correctAnswer();
    }

    public void onWrongAnswer()
    {
        Debug.Log("Wrong answer");
    }

}
