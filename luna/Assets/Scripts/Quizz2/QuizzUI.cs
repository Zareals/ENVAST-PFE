using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizzUI : MonoBehaviour
{
    [SerializeField] QuizzManager manager;
    [SerializeField] TMP_Text questionText;
    [SerializeField]  Image questionImage;
    [SerializeField] AudioSource questionAudio;
    [SerializeField] List<Button> options;
    [SerializeField] Color correctCol, wrongCol, normalCol;

    private QuizzManager.Question question;
    private bool answered;

    private void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    public void SetQuestion(QuizzManager.Question question)
    {
        this.question = question;

        switch (question.questionType)
        {
            case QuizzManager.QuestionType.TEXT:
                //questionImage.transform.parent.gameObject.SetActive(false);
                questionImage.gameObject.SetActive(false);
                break;
            case QuizzManager.QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImage;
                break;
            case QuizzManager.QuestionType.AUDIO:
                ImageHolder();
                questionAudio.transform.gameObject.SetActive(true);
                StartCoroutine(PlayAudio());
                break;
            case QuizzManager.QuestionType.VIDEO:
                ImageHolder();
                break;
            default:
                break;
        }

        questionText.text = question.questionInfo;

        List<string> answerList = RandomizeQuestions.ShuffleListItems<string>(question.options);

        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<TMP_Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCol;
        }

        answered = false;
    }

    IEnumerator PlayAudio()
    {
        if (question.questionType == QuizzManager.QuestionType.AUDIO)
        {
            questionAudio.PlayOneShot(question.questionClip);

            yield return new WaitForSeconds(question.questionClip.length + 1);

            StartCoroutine(PlayAudio());
        }
        else
        {
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }

    void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
        questionAudio.transform.gameObject.SetActive(false);
    }

    private void OnClick(Button button)
    {
        if (!answered)
        {
            answered = true;
            bool val = manager.Answer(button.name);

            if (val)
            {
                button.image.color = correctCol;
            }
            else
            {
                button.image.color = wrongCol;
            }
        }
    }
}
