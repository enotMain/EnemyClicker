using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RecordsBtn : MonoBehaviour
{
    [SerializeField] private Canvas _UICanvas;
    [SerializeField] private Canvas _recordsCanvas;
    private Button _recordBtn;

    private void Awake()
    {
        _recordBtn = GetComponent<Button>();
    }

    private void Start()
    {
        _recordBtn.onClick.AddListener(OpenRecords);
    }

    private void OpenRecords()
    {
        _UICanvas.gameObject.SetActive(false);
        _recordsCanvas.gameObject.SetActive(true);
    }
}
