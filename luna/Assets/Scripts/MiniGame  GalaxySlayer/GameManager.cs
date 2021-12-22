using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pnl;
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        pnl.SetActive(false);
        Time.timeScale = 1f;
    }
}
