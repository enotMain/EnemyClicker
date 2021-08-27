using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class EnemiesCountText : MonoBehaviour
{
    [SerializeField] private GameObject _vikingCountDetectionGO;
    private Text _textEnemiesCoint;
    private int _enemiesCount;

    public int EnemiesCount 
    { 
        get => _enemiesCount;
        set 
        {
            if (_enemiesCount == value) return;
            _enemiesCount = value;
            OnEnemiesCountChange?.Invoke(_enemiesCount);
            if (_enemiesCount >= _vikingCountDetectionGO.GetComponent<VikingCountDetection>().VikingCountToDefeat)
                _vikingCountDetectionGO.GetComponent<VikingCountDetection>().IsItDefeat = true;
        }
    }

    public delegate void OnEnemiesCountChangeDelegate(int enemiesCount);
    public event OnEnemiesCountChangeDelegate OnEnemiesCountChange;

    private void Awake()
    {
        _textEnemiesCoint = GetComponent<Text>();
        _enemiesCount = 0;
        OnEnemiesCountChange += ChangeTextByEnemiesCount;
    }

    private void Start()
    {
        ChangeTextByEnemiesCount(_enemiesCount);
    }

    private void ChangeTextByEnemiesCount(int enemiesCount)
    {
        _textEnemiesCoint.text = $"Enemies count: {enemiesCount}";
    }
}
