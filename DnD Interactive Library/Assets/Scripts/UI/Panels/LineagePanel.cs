using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LineagePanel : Panel
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _text;

    private string _lineageName;
    private string _dataString;

    public override void SetData(string name)
    {
        _header.text = name;
        _lineageName = name;
        StartCoroutine(GetText());
    }

    private void OnDisable()
    {
        _text.text = "";
    }

    private IEnumerator GetText()
    {
        Debug.Log(_lineageName);
        WWWForm form = new WWWForm();
        form.AddField("lineageName", _lineageName);
        WWW www = new WWW("http://localhost/get_info_lineage.php", form);
        yield return www;
        _dataString = www.text;
        _text.text = _dataString;
    }
}