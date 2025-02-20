using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI NamesText;
    public TextMeshProUGUI ScoresText;
    // Start is called before the first frame update
    void Start()
    {
        string allTheNames = $"{GameState.Instance.HighScore1Player}\n{GameState.Instance.HighScore2Player}\n{GameState.Instance.HighScore3Player}\n{GameState.Instance.HighScore4Player}\n{GameState.Instance.HighScore5Player}";
        NamesText.text = allTheNames;

        string allTheScores = $"{GameState.Instance.HighScore1}\n{GameState.Instance.HighScore2}\n{GameState.Instance.HighScore3}\n{GameState.Instance.HighScore4}\n{GameState.Instance.HighScore5}\n";
        ScoresText.text = allTheScores;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("settings");
        }
    }
}
