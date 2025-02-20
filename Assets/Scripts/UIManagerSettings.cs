using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerSettings : MonoBehaviour
{
    public Slider DifficultySlider;

    // Start is called before the first frame update
    void Start()
    {
        if (GameState.Instance.Difficulty < 3.0f)
        {
            GameState.Instance.Difficulty = 3.0f;
        }    
        DifficultySlider.SetValueWithoutNotify(GameState.Instance.Difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
    }

    public void GoBack()
    {
        GameState.Instance.SaveAll();
        SceneManager.LoadScene("start menu");
    }

    public void ShowScores()
    {
        SceneManager.LoadScene("scoreboard");
    }

    public void ClearScores()
    {
        GameState.Instance.ClearScores();
    }

    public void setDifficulty(float difficulty)
    {
        GameState.Instance.Difficulty = difficulty;
    }
}
