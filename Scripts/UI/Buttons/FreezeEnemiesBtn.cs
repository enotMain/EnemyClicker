using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FreezeEnemiesBtn : MonoBehaviour
{
    [SerializeField] private float _freezeTime;
    private Button _freezeBtn;
    private GameObject[] _enemies;
    private List<float> _enemiesSpeed;

    private void Awake()
    {
        _freezeBtn = GetComponent<Button>();
        _enemiesSpeed = new List<float>();
    }

    private void Start()
    {
        _freezeBtn.onClick.AddListener(FreezeAllEnemies);
    }

    private void FreezeAllEnemies()
    {
        LockBtn();

        _enemies = GameObject.FindGameObjectsWithTag("Viking");
        foreach (GameObject enemy in _enemies)
        {
            _enemiesSpeed.Add(enemy.GetComponent<Viking>().Speed);
            enemy.GetComponent<Viking>().Speed = 0;
        }

        StartCoroutine(TimerDefrostEnemies());
    }

    private IEnumerator TimerDefrostEnemies()
    {
        yield return new WaitForSeconds(_freezeTime);
        DefrostEnemies();
    }

    private void LockBtn()
    {
        _freezeBtn.interactable = false;
    }

    private void DefrostEnemies()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null) _enemies[i].GetComponent<Viking>().Speed = _enemiesSpeed[i];
        }
    }
}
