using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public string PlayerName;
    public string HighScorePlayer;
    public int HighScore;

    public static GameState Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveData
    {
        public int HScore;
        public string HSPlayer;
    }

    public void SaveScores()
    {
        SaveData data = new SaveData();
        data.HScore = HighScore;
        data.HSPlayer = HighScorePlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/pongsavefile.json", json);
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/pongsavefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HScore;
            HighScorePlayer = data.HSPlayer;
        }
    }
}
