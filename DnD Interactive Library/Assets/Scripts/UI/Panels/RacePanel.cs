using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RacePanel : Panel
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _text;

    private string _raceName;
    private string _dataString;

    public override void SetData(string name)
    {
        _header.text = name;
        _raceName = name;
        StartCoroutine(GetText());
    }

    private void OnDisable()
    {
        _text.text = "";
    }

    private IEnumerator GetText()
    {
        Debug.Log(_raceName);
        WWWForm form = new WWWForm();
        form.AddField("raceName", _raceName);
        WWW www = new WWW("http://localhost/get_info_race.php", form);
        yield return www;
        _dataString = www.text;
        _text.text = _dataString;
    }
}
