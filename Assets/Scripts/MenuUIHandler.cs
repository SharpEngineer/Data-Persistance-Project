using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerName1;
    public TextMeshProUGUI playerName2;
    public TextMeshProUGUI playerName3;
    public TextMeshProUGUI playerName4;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    private void Start()
    {
        playerName1.text = GameManager.Instance.playerName1;
        if(playerName1.text == "") {
            playerName1.text = "Play to get 1st place";
        }
        playerName2.text = GameManager.Instance.playerName2;
        if(playerName2.text == "") {
            playerName2.text = "Play to get 2nd place";
        }
        playerName3.text = GameManager.Instance.playerName3;
        if(playerName3.text == "") {
            playerName3.text = "Play to get 3rd place";
        }
        playerName4.text = GameManager.Instance.playerName4;
        if(playerName4.text == "") {
            playerName4.text = "Play to get 4th place";
        }
        score1.text = GameManager.Instance.score1.ToString();
        score2.text = GameManager.Instance.score2.ToString();
        score3.text = GameManager.Instance.score3.ToString();
        score4.text = GameManager.Instance.score4.ToString();
    }
    public void StartNew()
    {
        GameManager.Instance.playerName = playerName.text;
        SceneManager.LoadScene(1);
    }
    public void Exit() {
        GameManager.Instance.SaveScores();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else 
        Application.Quit();
        #endif
    }

    public string RetriveName()
    {
        return playerName.text;
    }

}