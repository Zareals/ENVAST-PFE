using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManger quizManger;

    public void Click() 
    {
        if (isCorrect)
        {
            quizManger.Correct();
            quizManger.AddScore(10);
            Debug.Log("True");
            Debug.Log(quizManger.localScore);
        }
        else
        {
            quizManger.Correct();
            Debug.Log("F");
            quizManger.AddScore(10);
        }
    }
}
