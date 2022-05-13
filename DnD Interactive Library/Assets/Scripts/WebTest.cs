using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System;

public class WebTest : MonoBehaviour
{
    [SerializeField] private CanvasListController _canvas;

    private string _dataString;
    private string _header;
    private string[] _dataArray;

    public static event Action<string, string[]> OnTextChanged;
    public static event Action OnTextCleared;

    public bool TextIsShown { get; private set; }

    public IEnumerator GetText(string fileName, string parameters)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/" + fileName + ".php" + parameters))
        {
            TextIsShown = true;
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
                _dataString = www.error;
            else
                _dataString = www.downloadHandler.text;

            _dataArray = _dataString.Split(';');
            _header = _dataArray[0];

            _canvas.gameObject.SetActive(true);
            OnTextChanged?.Invoke(_header, _dataArray);
        }
    }

    public void ClearText()
    {
        _dataString = "";
        Array.Clear(_dataArray, 0, _dataArray.Length);
        TextIsShown = false;

        OnTextCleared?.Invoke();
        _canvas.gameObject.SetActive(false);
    }
}
