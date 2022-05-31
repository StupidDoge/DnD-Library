using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionCollider : MonoBehaviour
{
    public static Action<string> OnHintCanvasShow;
    public static Action<string, string, string> OnListOpened;

    public static bool CanvasIsActive;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private Canvas _hintCanvas;

    [SerializeField] private string _textToShow;

    [SerializeField] private string _header;
    [SerializeField] private string _phpFileName;
    [SerializeField] private string _tableName;

    private bool _isPlayerEnabled = true;

    private void OnTriggerEnter(Collider other)
    {
        _hintCanvas.gameObject.SetActive(true);
        OnHintCanvasShow?.Invoke(_textToShow);
    }

    private void OnTriggerExit(Collider other)
    {
        _hintCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.enabled = _isPlayerEnabled;
        }
    }

    public void ShowCanvas()
    {
        _canvas.gameObject.SetActive(true);
        _isPlayerEnabled = false;
        CanvasIsActive = true;
        Cursor.lockState = CursorLockMode.None;
        OnHintCanvasShow?.Invoke("");
        OnListOpened?.Invoke(_header, _phpFileName, _tableName);
    }

    public void HideCanvas()
    {
        _canvas.gameObject.SetActive(false);
        _isPlayerEnabled = true;
        CanvasIsActive = false;
        Cursor.lockState = CursorLockMode.Locked;
        OnHintCanvasShow?.Invoke(_textToShow);
    }
}
