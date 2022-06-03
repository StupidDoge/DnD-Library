using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArchetypePanel : Panel
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _text;

    private string _archetypeName;
    private string _dataString;

    public override void SetData(string name)
    {
        _header.text = name;
        _archetypeName = name;
        StartCoroutine(GetText());
    }

    private void OnDisable()
    {
        _text.text = "";
    }

    private IEnumerator GetText()
    {
        Debug.Log(_archetypeName);
        WWWForm form = new WWWForm();
        form.AddField("archetypeName", _archetypeName);
        WWW www = new WWW("http://localhost/get_archetype.php", form);
        yield return www;
        _dataString = www.text;
        _dataString = _dataString.Replace("&;", "<br>");
        _text.text = _dataString;
    }
}
