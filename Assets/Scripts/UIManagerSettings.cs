using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("start menu");
        }
    }

    public void ShowScores()
    {
        SceneManager.LoadScene("scoreboard");
    }

    public void ClearScores()
    {
        GameState.Instance.ClearScores();
    }
}
