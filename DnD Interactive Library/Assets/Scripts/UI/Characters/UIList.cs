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
    [SerializeField] private GameObject _dragonsPanel;
    [SerializeField] private GameObject _classPanel;
    [SerializeField] private GameObject _archetypePanel;
    [SerializeField] private GameObject _classSkillsPanel;
    [SerializeField] private GameObject _additionalSkillsPanel;

    private GameObject _activePanel;

    private string _tableName;
    private string _dataString;
    private string[] _dataArray;

    private string _request = "http://localhost/get_races.php";

    private Line[] _lines;

    private void OnEnable()
    {
        StartCoroutine(Wait());
        Line.OnRawSelected += SwapPanels;
        InteractionCollider.CanvasIsActive = true;
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

        _dataArray = _dataString.Split(';');

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
            case "dragons_types":
                _activePanel = _dragonsPanel;
                break;
            case "class":
                _activePanel = _classPanel;
                break;
            case "archetype":
                _activePanel = _archetypePanel;
                break;
            case "class_skills":
                _activePanel = _classSkillsPanel;
                break;
            case "additional_skills":
                _activePanel = _additionalSkillsPanel;
                break;
        }

        for (int i = 0; i < _dataArray.Length; i++)
        {
            if (_dataArray[i] != "")
            {

                if (_activePanel == _additionalSkillsPanel || _activePanel == _classSkillsPanel)
                {
                    string[] tempArray = _dataArray[i].Split('&');
                    GameObject skillLine = Instantiate(_template);
                    skillLine.transform.SetParent(_container.transform);
                    skillLine.GetComponent<Line>().SetData(tempArray[0], tempArray[1], _activePanel);
                } else
                {
                    string characterInfo = _dataArray[i];
                    GameObject line = Instantiate(_template);
                    line.transform.SetParent(_container.transform);
                    line.GetComponent<Line>().SetData(characterInfo, _activePanel);
                }
            }
        }

        _lines = FindObjectsOfType<Line>();
        _request = "http://localhost/get_races.php";
    }
}
