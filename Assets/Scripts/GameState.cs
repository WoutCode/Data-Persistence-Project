using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class GameState : MonoBehaviour
{

    public string PlayerName;
    public float Difficulty;

    // For high scores, I would have preferred to use a SortedList or something,
    // but we're serializing to json for now and that wouldn't work.
    // I'm aware this is lame and leads to repetitive code.
    //
    public int HighScore1;
    public string HighScore1Player;
    public int HighScore2;
    public string HighScore2Player;
    public int HighScore3;
    public string HighScore3Player;
    public int HighScore4;
    public string HighScore4Player;
    public int HighScore5;
    public string HighScore5Player;
    
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

    public void ProcessScore(int score)
    {
        if (PlayerName == "") PlayerName = "Nemo";

        if (score >  HighScore5 && score <= HighScore4) 
        {
            HighScore5 = score;
            HighScore5Player = PlayerName;
        }
        else if (score >  HighScore4 && score <= HighScore3) 
        {
            HighScore5 = HighScore4;
            HighScore5Player = HighScore4Player;
            HighScore4 = score;
            HighScore4Player = PlayerName;
        }
        else if (score >  HighScore3 && score <= HighScore2)
        {
            HighScore5 = HighScore4;
            HighScore5Player = HighScore4Player;
            HighScore4 = HighScore3;
            HighScore4Player = HighScore3Player;
            HighScore3 = score;
            HighScore3Player = PlayerName;
        }
        else if (score >  HighScore2 && score <= HighScore1)
        {
            HighScore5 = HighScore4;
            HighScore5Player = HighScore4Player;
            HighScore4 = HighScore3;
            HighScore4Player = HighScore3Player;
            HighScore3 = HighScore2;
            HighScore3Player = HighScore2Player;
            HighScore2 = score;
            HighScore2Player = PlayerName;
        }
        else if (score >  HighScore1)
        {
            HighScore5 = HighScore4;
            HighScore5Player = HighScore4Player;
            HighScore4 = HighScore3;
            HighScore4Player = HighScore3Player;
            HighScore3 = HighScore2;
            HighScore3Player = HighScore2Player;
            HighScore2 = HighScore1;
            HighScore2Player = HighScore1Player;
            HighScore1 = score;
            HighScore1Player = PlayerName;
        }

        SaveAll();
    }

    [System.Serializable]
    class SaveData
    {
        public float DifficultyLevel;
        public int HScore1;
        public string HS1Player;
        public int HScore2;
        public string HS2Player;
        public int HScore3;
        public string HS3Player;
        public int HScore4;
        public string HS4Player;
        public int HScore5;
        public string HS5Player;
    }

    public void SaveAll()
    {
        SaveData data = new SaveData();
        data.DifficultyLevel = Difficulty;
        data.HScore1 = HighScore1;
        data.HS1Player = HighScore1Player;
        data.HScore2 = HighScore2;
        data.HS2Player = HighScore2Player;
        data.HScore3 = HighScore3;
        data.HS3Player = HighScore3Player;
        data.HScore4 = HighScore4;
        data.HS4Player = HighScore4Player;
        data.HScore5 = HighScore5;
        data.HS5Player = HighScore5Player;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/pongsavefile.json", json);
    }

    public void LoadAll()
    {
        string path = Application.persistentDataPath + "/pongsavefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Difficulty = data.DifficultyLevel;
            HighScore1 = data.HScore1;
            HighScore1Player = data.HS1Player;
            HighScore2 = data.HScore2;
            HighScore2Player = data.HS2Player;
            HighScore3 = data.HScore3;
            HighScore3Player = data.HS3Player;
            HighScore4 = data.HScore4;
            HighScore4Player = data.HS4Player;
            HighScore5 = data.HScore5;
            HighScore5Player = data.HS5Player;
        }
    }

    public void ClearScores()
    {
        Debug.Log("Clearing scores.");
        HighScore1 = 0;
        HighScore1Player = "Nemo";
        HighScore2 = 0;
        HighScore2Player = "Nemo";
        HighScore3 = 0;
        HighScore3Player = "Nemo";
        HighScore4 = 0;
        HighScore4Player = "Nemo";
        HighScore5 = 0;
        HighScore5Player = "Nemo";

        SaveAll();
    }
}
