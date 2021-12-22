using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public void SelectScene(int i)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(i);
    }
}
