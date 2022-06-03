using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClassPanel : Panel
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _text;

    private string _className;
    private string _dataString;

    public override void SetData(string name)
    {
        _header.text = name;
        _className = name;
        StartCoroutine(GetText());
    }

    private void OnDisable()
    {
        _text.text = "";
    }

    private IEnumerator GetText()
    {
        Debug.Log(_className);
        WWWForm form = new WWWForm();
        form.AddField("className", _className);
        WWW www = new WWW("http://localhost/get_info_class.php", form);
        yield return www;
        _dataString = www.text;
        _dataString = _dataString.Replace("&;", "<br>");
        _text.text = _dataString;
    }
}
