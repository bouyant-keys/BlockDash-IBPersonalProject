using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    ProgressManager _progressManager;
    Button _thisButton;

    public int _levelNum;
    //bool _isLocked = true;

    private void Awake()
    {
        _progressManager = GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<ProgressManager>();
    }

    private void Start()
    {
        _thisButton = gameObject.GetComponent<Button>();
        _thisButton.interactable = false;

        if (_progressManager._levelProgress[_levelNum-1] == true)
        {
            _thisButton.interactable = true;
        }
    }
}
