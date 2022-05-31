using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubracePanel : Panel
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _text;

    private string _subraceName;
    private string _dataString;

    public override void SetData(string name)
    {
        _header.text = name;
        _subraceName = name;
        StartCoroutine(GetText());
    }

    private void OnDisable()
    {
        _text.text = "";
    }

    private IEnumerator GetText()
    {
        Debug.Log(_subraceName);
        WWWForm form = new WWWForm();
        form.AddField("subraceName", _subraceName);
        WWW www = new WWW("http://localhost/get_info_subrace.php", form);
        yield return www;
        _dataString = www.text;
        _text.text = _dataString;
    }
}
