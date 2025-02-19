using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMenu : MonoBehaviour
{
    public GameObject HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameState.Instance.LoadScores();
        HighScoreText.GetComponent<TextMeshProUGUI>().SetText($"Best score : {GameState.Instance.HighScorePlayer} : {GameState.Instance.HighScore}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NameEntered(string playerName)
    {
        GameState.Instance.PlayerName = playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit;
#endif
    }
}
