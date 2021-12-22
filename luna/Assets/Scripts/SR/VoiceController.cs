using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;
using TMPro;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";

    [SerializeField]
    TMP_Text uiText;

    //public VoiceController instance;

    
    private void Start()
    {
        Setup(LANG_CODE);
        
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;

        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakEnd;

        CheckPermition();
    }

    void CheckPermition()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    #region Text to Speech
    public void StratSpeeking(string message)
    {
        if (uiText.text != "")
        {
            TextToSpeech.instance.StartSpeak(uiText.text);
        }
        else
        {
            TextToSpeech.instance.StartSpeak(message);
        }
    }

    public void stopSpeeking()
    {
        TextToSpeech.instance.StopSpeak();
    }

    void OnSpeakStart()
    {
        Debug.Log("it speaks");
    }

    void OnSpeakEnd()
    {
        Debug.Log("Yea Thanks");
    }
    #endregion

    #region Speech to Text
    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        uiText.text = '\u0022' + result + '\u0022';
    }
    void OnPartialSpeechResult(string result)
    {
        uiText.text = '\u0022' + result + '\u0022';
    }
    #endregion
    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }
}
