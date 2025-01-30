using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string playerName1;
    public string playerName2;
    public string playerName3;
    public string playerName4;
    public int score;
    public int score1;
    public int score2;
    public int score3;
    public int score4;

    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScores();
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName1;
        public string playerName2;
        public string playerName3;
        public string playerName4;
        public int score1;
        public int score2;
        public int score3;
        public int score4;
    }
    public void SaveScores()
    {
    SaveData data = new SaveData();
    data.playerName1 = playerName1;
    data.playerName2 = playerName2;
    data.playerName3 = playerName3;
    data.playerName4 = playerName4;
    data.score1 = score1;
    data.score2 = score2;
    data.score3 = score3;
    data.score4 = score4;


    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScores()
    {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        playerName1 = data.playerName1;
        playerName2 = data.playerName2;
        playerName3 = data.playerName3;
        playerName4 = data.playerName4;
        score1 = data.score1;
        score2 = data.score2;
        score3 = data.score3;
        score4 = data.score4;
    }
    }

    public void UpdateScores() {
        UnityEngine.Debug.Log("Score in GameManager is " + GameManager.Instance.score);
        if(score > score1) {
            playerName4 = playerName3;
            playerName3 = playerName2;
            playerName2 = playerName1;
            playerName1 = playerName;
            score4 = score3;
            score3 = score2;
            score2 = score1;
            score1 = score;
        }
        else if(score > score2) {
            playerName4 = playerName3;
            playerName3 = playerName2;
            playerName2 = playerName;
            score4 = score3;
            score3 = score2;
            score2 = score;
        }
        else if(score > score3) {
            playerName4 = playerName3;
            playerName3 = playerName;
            score4 = score3;
            score3 = score;
        }
        else if(score > score4) {
            playerName4 = playerName;
            score4 = score;
        }
        else {

        }
    }
}
