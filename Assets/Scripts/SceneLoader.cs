using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    string _levelName;
    public int GetCurrentLevelIndex()
    {
        _levelName = SceneManager.GetActiveScene().name;
        int levelIndex = int.Parse(_levelName.Substring(_levelName.IndexOf("_") + 1));

        return levelIndex;
    }
}
