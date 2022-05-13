using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasListController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        WebTest.OnTextChanged += SetText;
        WebTest.OnTextCleared += ClearText;
    }

    private void OnDisable()
    {
        WebTest.OnTextChanged -= SetText;
        WebTest.OnTextCleared -= ClearText;
    }

    private void SetText(string header, string[] dataArray)
    {
        _header.text = header;
        for (int i = 1; i < dataArray.Length; i++)
            _text.text += dataArray[i];
    }

    private void ClearText()
    {
        _header.text = "";
        _text.text = "";
    }
}
