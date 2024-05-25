using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{

    public int _numberOfLevels = 5;
    public bool[] _levelProgress;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ProgressManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _levelProgress = new bool[_numberOfLevels];
        for (int i = 0; i < _levelProgress.Length; i++)
        {
            if (i == 0)
            {
                _levelProgress[i] = true;
            }
            else
            {
                _levelProgress[i] = false;
            }
        }
    }

    public void UpdateProgress(int level)
    {
        if (level < _numberOfLevels)
        {
            for (int i = level; i > -1; i--)
            {
                _levelProgress[i] = true;
            }
        }
        //_currentScene = SceneManager.GetActiveScene().name;
        //_levelProgress[int.Parse(_currentScene.Substring(_currentScene.IndexOf("_") + 1))] = 1;
    }
}
