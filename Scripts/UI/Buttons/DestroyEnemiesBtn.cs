using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DestroyEnemiesBtn : MonoBehaviour
{
    private Button _destroyBtn;

    private void Awake()
    {
        _destroyBtn = GetComponent<Button>();
    }

    private void Start()
    {
        _destroyBtn.onClick.AddListener(DestroyEnemies);
    }

    private void LockBtn()
    {
        _destroyBtn.interactable = false;
    }

    private void DestroyEnemies()
    {
        LockBtn();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Viking");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Viking>().ResetHP();
        }
    }
}
