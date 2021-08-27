using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackMenuFromRecordsBtn : MonoBehaviour
{
    [SerializeField] Canvas _UICanvas;
    [SerializeField] Canvas _recordsCanvas;
    private Button _backMenuBtn;

    private void Awake()
    {
        _backMenuBtn = GetComponent<Button>();
    }

    private void Start()
    {
        _backMenuBtn.onClick.AddListener(BackToMenuAction);
    }

    private void BackToMenuAction()
    {
        _UICanvas.gameObject.SetActive(true);
        _recordsCanvas.gameObject.SetActive(false);
    }
}
