using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMenuBtn : MonoBehaviour
{
    Button _menuBtn;

    private void Awake()
    {
        _menuBtn = GetComponent<Button>();
    }

    private void Start()
    {
        _menuBtn.onClick.AddListener(LoadMenuScene);
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
