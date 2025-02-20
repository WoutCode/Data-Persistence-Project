using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UI;

#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerMenu : MonoBehaviour
{
    //public GameObject HighScoreText;
    public TextMeshProUGUI HighScoreText;
    public TMP_InputField NameText;

    // Start is called before the first frame update
    void Start()
    {
        GameState.Instance.LoadAll();
        HighScoreText.SetText($"Best score : {GameState.Instance.HighScore1Player} : {GameState.Instance.HighScore1}");
               if (GameState.Instance.PlayerName != null) 
        {
            NameText.text = GameState.Instance.PlayerName;
        }
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

    public void OpenSettings()
    {
        SceneManager.LoadScene("settings");
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
