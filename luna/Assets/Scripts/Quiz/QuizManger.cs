using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

public class QuizManger : MonoBehaviour
{
    public List<QuistionsAndAnswers> QaA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text Question;
    public int localScore;

    public SaveData save;

    private void Start()
    {
        RandomizeQuestion();
    }

    public void Correct()
    {
        //QaA.RemoveAt(currentQuestion);
        //RandomizeQuestion();
        save.SaveScore(localScore);
    }

    void SetOptions()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QaA[currentQuestion].Answers[i];
            Debug.Log(i + 1);

            if (QaA[currentQuestion].correctAnswer == i+1 )
            {
                options[i].GetComponent<Image>().color = new Color(34, 139, 34);
                options[i].GetComponent<Answers>().isCorrect = true;
            }
            else
            {
                options[i].GetComponent<Image>().color = new Color(255, 0, 0);
            }
        }
    }

    void RandomizeQuestion()
    {
        currentQuestion = Random.Range(0, QaA.Count);

        Question.text = QaA[currentQuestion].Question;
        SetOptions();
    }

    public void AddScore(int points)
    {
        localScore = localScore + points;
    }
}
