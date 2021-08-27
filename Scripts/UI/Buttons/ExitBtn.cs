using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBtn : MonoBehaviour
{
    private Button _buttonExit;

    private void Awake()
    {
        _buttonExit = GetComponent<Button>();
    }

    private void Start()
    {
        _buttonExit.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
