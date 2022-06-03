using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Line : MonoBehaviour
{
    public static Action<string> OnRawSelected;

    [SerializeField] private TextMeshProUGUI _name;

    private int _id;
    private bool _haveSeparateID;

    public GameObject _panelToShow;

    public void SetData(string data, GameObject panel)
    {
        _name.text = data;
        _panelToShow = panel;
    }

    public void SetData(string id, string data, GameObject panel)
    {
        _haveSeparateID = true;
        _id = int.Parse(id);
        _name.text = data;
        _panelToShow = panel;
        Debug.Log(_id);
    }

    public void PressButton()
    {
        if (_haveSeparateID)
            OnRawSelected?.Invoke(_id.ToString() + "&" + _name.text);
        else
            OnRawSelected?.Invoke(_name.text);
    }
}
