using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public string selection;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void ChangeSelection(string sel)
    {
        selection = sel;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void GameOverScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }

    public void GameWinnerScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Winner");
    }
}
