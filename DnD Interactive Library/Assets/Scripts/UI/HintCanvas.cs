using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HintCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hint;

    private void OnEnable()
    {
        InteractionCollider.OnHintCanvasShow += SetText;
    }

    private void OnDisable()
    {
        InteractionCollider.OnHintCanvasShow -= SetText;
    }

    private void SetText(string text)
    {
        _hint.text = text;
    }
}
