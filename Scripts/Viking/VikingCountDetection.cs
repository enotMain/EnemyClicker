using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VikingCountDetection : MonoBehaviour
{
    [SerializeField] private int _vikingCountToDefeat;
    [SerializeField] private GameObject _scoreGO;
    private bool _isItDefeat;

    public bool IsItDefeat 
    { 
        get => _isItDefeat;
        set
        {
            if (_isItDefeat == value) return;
            _isItDefeat = value;
            OnDefeatCondition?.Invoke();
        }
    }
    public int VikingCountToDefeat { get => _vikingCountToDefeat; set => _vikingCountToDefeat = value; }

    public delegate void OnDefeatConditionDelegate();
    public event OnDefeatConditionDelegate OnDefeatCondition;

    private void Awake()
    {
        OnDefeatCondition += ActionOnDefeat;
        _isItDefeat = false;
    }

    private void ActionOnDefeat()
    {
        Time.timeScale = 0f;
        SetUINotActive();
        _scoreGO.transform.position = new Vector3(Camera.current.transform.position.x,
            Camera.current.transform.position.y,
            0);
        _scoreGO.transform.localScale *= 2f;
        StartCoroutine(WaitForLoadMenu());
    }

    private void SetUINotActive()
    {
        GameObject.FindGameObjectWithTag("UI").SetActive(false);
    }

    private IEnumerator WaitForLoadMenu()
    {
        yield return new WaitForSecondsRealtime(3f);
        DataController.Instance.WriteNewRecordDataAsync(DateTime.Now.ToString() + " " +_scoreGO.GetComponent<ScoreText>().ScoreCount);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
