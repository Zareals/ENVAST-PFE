using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizzManager : MonoBehaviour
{
    [SerializeField] private QuizzUI quizzUI;

    [SerializeField]
    private List<Question> questions;
    private Question selectedQuestion;

    void Start()
    {
        SelectQuestion();
    }

    void SelectQuestion()
    {
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizzUI.SetQuestion(selectedQuestion);
    }

    public bool Answer(string answered)
    {
        bool correctAns = false;

        if (answered == selectedQuestion.correctAns)
        {
            correctAns = true;
        }
        else
        {

        }

        Invoke("SelectQuestion", 0.4f);

        return correctAns;
    }

    //Datastructure for storing the quetions data
    [System.Serializable]
    public class Question
    {
        public string questionInfo;         //question text
        public QuestionType questionType;   //type
        public Sprite questionImage;        //image for Image Type
        public AudioClip questionClip;         //audio for audio type
        public UnityEngine.Video.VideoClip videoClip;   //video for video type
        public List<string> options;        //options to select
        public string correctAns;           //correct option
    }

    [System.Serializable]
    public enum QuestionType
    {
        TEXT,
        IMAGE,
        AUDIO,
        VIDEO
    }

    [SerializeField]
    public enum GameStatus
    {
        PLAYING,
        NEXT
    }
}
