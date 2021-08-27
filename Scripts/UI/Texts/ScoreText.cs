using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    private Text _scoreText;
    private int _scoreCount;

    public int ScoreCount
    { 
        get => _scoreCount;
        set
        {
            if (_scoreCount == value) return;
            _scoreCount = value;
            OnScoreCountChange?.Invoke(_scoreCount);
        }
    }

    public delegate void OnScoreCountChangeDelegate(int score);
    public event OnScoreCountChangeDelegate OnScoreCountChange;

    private void Awake()
    {
        _scoreText = GetComponent<Text>();
        _scoreCount = 0;
        OnScoreCountChange += ChangeScoreText;
    }

    private void Start()
    {
        ChangeScoreText(_scoreCount);
    }

    private void ChangeScoreText(int score)
    {
        _scoreText.text = $"Score: {_scoreCount}";
    }
}
