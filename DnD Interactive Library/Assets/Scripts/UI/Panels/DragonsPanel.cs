using System.Collections;
using TMPro;
using UnityEngine;

public class DragonsPanel : Panel
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _text;

    private string _dragonType;
    private string _dataString;

    public override void SetData(string name)
    {
        _header.text = name;
        _dragonType = name;
        StartCoroutine(GetText());
    }

    private void OnDisable()
    {
        _text.text = "";
    }

    private IEnumerator GetText()
    {
        Debug.Log(_dragonType);
        WWWForm form = new WWWForm();
        form.AddField("dragonType", _dragonType);
        WWW www = new WWW("http://localhost/get_info_dragons.php", form);
        yield return www;
        _dataString = www.text;
        _dataString = _dataString.Replace("&;", "<br>");
        _text.text = _dataString;
    }
}
