using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameBtn : MonoBehaviour
{
    private Button _buttonNewGame;

    private void Awake()
    {
        _buttonNewGame = GetComponent<Button>();
    }

    private void Start()
    {
        _buttonNewGame.onClick.AddListener(ChangeSceneToPlayGround);
    }

    private void ChangeSceneToPlayGround()
    {
        SceneManager.LoadScene("PlayGround");
    }
}
