using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnswer : MonoBehaviour
{

    public delegate void PuzzleEvent();
    public static event PuzzleEvent correctAnswer;

    public NumberSlot one;
    public NumberSlot two;
    public NumberSlot three;

    public void onCorrectAnswer()
    {
        if(one.occupied && two.occupied && three.occupied)
        {
            Debug.Log("correct answer");
            correctAnswer();
        }
        else
        {
            Debug.Log("wrong answer");
        }
        
    }

    public void onWrongAnswer()
    {
        Debug.Log("Wrong answer");
    }

}
