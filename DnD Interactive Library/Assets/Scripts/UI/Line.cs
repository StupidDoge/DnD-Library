using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Line : MonoBehaviour
{
    public static Action<string> OnRawSelected;

    [SerializeField] private TextMeshProUGUI _name;

    public GameObject _panelToShow;

    public void SetData(string data, GameObject panel)
    {
        _name.text = data;
        _panelToShow = panel;
    }

    public void PressButton()
    {
        OnRawSelected?.Invoke(_name.text);
    }
}
