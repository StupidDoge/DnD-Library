using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdditionalSkillsPanel : Panel
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _text;

    private string _additionalSkillID;
    private string _dataString;

    public override void SetData(string idWithName)
    {
        Debug.Log(idWithName);
        string[] data = idWithName.Split('&');
        _header.text = data[1];
        _additionalSkillID = data[0];
        StartCoroutine(GetText());
    }

    private void OnDisable()
    {
        _text.text = "";
    }

    private IEnumerator GetText()
    {
        Debug.Log(_additionalSkillID);
        WWWForm form = new WWWForm();
        form.AddField("skillID", _additionalSkillID);
        WWW www = new WWW("http://localhost/get_add_skills.php", form);
        yield return www;
        _dataString = www.text;
        _dataString = _dataString.Replace("&;", "<br>");
        _text.text = _dataString;
    }
}
