using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class UIList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _header;

    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _template;

    [Header("Panels")]
    [SerializeField] private GameObject _listPanel;
    [SerializeField] private GameObject _racePanel;
    [SerializeField] private GameObject _subracePanel;
    [SerializeField] private GameObject _lineagePanel;

    private GameObject _activePanel;

    private string _tableName;
    private string _dataString;
    private string[] _races;

    private string _request = "http://localhost/get_races.php";

    private Line[] _lines;

    private void OnEnable()
    {
        StartCoroutine(Wait());
        Line.OnRawSelected += SwapPanels;
    }

    private void OnDisable()
    {
        InteractionCollider.CanvasIsActive = false;
        InteractionCollider.OnListOpened -= ReceiveData;
        Line.OnRawSelected -= SwapPanels;
        foreach (Line line in _lines)
            Destroy(line.gameObject);

        _activePanel.SetActive(false);
        _listPanel.SetActive(true);
    }

    private void SwapPanels(string name)
    {
        _listPanel.SetActive(false);
        _activePanel.SetActive(true);
        _activePanel.GetComponent<Panel>().SetData(name);
    }

    private void ReceiveData(string header, string file, string table)
    {
        _header.text = header;
        _tableName = table;
        _request = "http://localhost/" + file + ".php?tableName=" + table;
    }

    public IEnumerator Wait()
    {
        InteractionCollider.OnListOpened += ReceiveData;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(GetText());
    }

    public IEnumerator GetText()
    {
        Debug.Log(_request);
        using UnityWebRequest www = UnityWebRequest.Get(_request);
        yield return www.Send();

        if (www.isNetworkError || www.isHttpError)
            _dataString = www.error;
        else
            _dataString = www.downloadHandler.text;

        _races = _dataString.Split(';');

        switch (_tableName)
        {
            case "race":
                _activePanel = _racePanel;
                break;
            case "subrace":
                _activePanel = _subracePanel;
                break;
            case "lineage":
                _activePanel = _lineagePanel;
                break;
        }

        for (int i = 0; i < _races.Length; i++)
        {
            if (_races[i] != "")
            {
                string characterInfo = _races[i];
                GameObject line = Instantiate(_template);
                line.transform.SetParent(_container.transform);
                line.GetComponent<Line>().SetData(characterInfo, _activePanel);
            }
        }

        _lines = FindObjectsOfType<Line>();
        _request = "http://localhost/get_races.php";
    }
}
