using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RecordScroll : MonoBehaviour
{
    private Text _recordsText;

    private void Awake()
    {
        _recordsText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _recordsText.text = DataController.Instance.ReadRecordsData();
    }
}
