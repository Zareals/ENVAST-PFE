using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;
using Firebase.Database;

public class LandingManager : MonoBehaviour
{
    public static LandingManager instance;

    public GameObject bg;
    public GameObject loginScreen;
    public GameObject registerScreen;
    public GameObject PlayerUsername;
    public GameObject TransEclipse;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    public void RegisterBtn()
    {
        bg.SetActive(true);
        bg.GetComponent<Image>().GetComponentInChildren<RectTransform>().LeanMoveY(208 * 2,0.75f);
        StartCoroutine(FadeLogin());
    }

    IEnumerator FadeLogin()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("hey");
        registerScreen.GetComponent<RectTransform>().LeanMoveY(0, 0.75f);
        bg.GetComponent<Image>().GetComponentInChildren<RectTransform>().LeanMoveY(-1038, 1f);

        yield return new WaitForSeconds(1.75f);
        bg.SetActive(false);
    }

    public void LoginBtn()
    {
        bg.SetActive(true);
        bg.GetComponent<Image>().GetComponentInChildren<RectTransform>().LeanMoveY(208 * 2, 1.25f);
        StartCoroutine(FadeRegister());
    }

    IEnumerator FadeRegister()
    {
        yield return new WaitForSeconds(1);
        registerScreen.GetComponent<RectTransform>().LeanMoveY(1300, 0.75f);
        bg.GetComponent<Image>().GetComponentInChildren<RectTransform>().LeanMoveY(-1038, 0.75f);


        yield return new WaitForSeconds(1.75f);
        bg.SetActive(false);
    }

    public void UserProfile()
    {
        StartCoroutine(LogIN());
    }

    public void LogOutBtn()
    {
        PlayerUsername.SetActive(false);
    }

    public void LoadGames(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    public void PlayTranstion()
    {
        TransEclipse.GetComponent<RectTransform>().LeanMoveX(2200, 0.75f);
    }

    IEnumerator LogIN()
    {
        yield return new WaitForSeconds(5f);
        PlayerUsername.SetActive(true);
    }
}
