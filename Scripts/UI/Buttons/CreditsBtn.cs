using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CreditsBtn : MonoBehaviour
{
    [SerializeField] private Canvas _creditsCanvas;
    [SerializeField] private Canvas _UICanvas;
    private Button _creditsBtn;

    private void Awake()
    {
        _creditsBtn = GetComponent<Button>();
    }

    private void Start()
    {
        _creditsBtn.onClick.AddListener(OpenCredits);
    }

    private void OpenCredits()
    {
        _creditsCanvas.gameObject.SetActive(true);
        _UICanvas.gameObject.SetActive(false);
    }
}
