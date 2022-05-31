using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterUpdateCharsheet : MonoBehaviour
{
    public static Action OnCharsheetUpdateButtonPressed;

    [SerializeField] private List<TMP_InputField> _inputFields;

    private string _dataString;
    private string[] _infoList;

    private int _id;

    private void OnEnable()
    {
        UIController.OnCharsheetOpened += SetCharsheet;
        InteractionCollider.CanvasIsActive = true;
    }

    private void OnDisable()
    {
        UIController.OnCharsheetOpened -= SetCharsheet;
        foreach (TMP_InputField field in _inputFields)
            field.text = "";
    }

    public void SetCharsheet(int id)
    {
        _id = id;
        Debug.Log("character id = " + _id);
        StartCoroutine(GetText());
    }

    public void UpdateCharacter()
    {
        StartCoroutine(UpdateCharacterInDatabase());
        Debug.Log("upd");
    }

    public void Cancel()
    {
        OnCharsheetUpdateButtonPressed?.Invoke();
        Debug.Log("cancel");
    }

    public IEnumerator GetText()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _id);
        WWW www = new WWW("http://localhost/get_character_charsheet.php", form);
        yield return www;
        _dataString = www.text;
        _infoList = _dataString.Split(';');
        SetInputFields();
    }

    private IEnumerator UpdateCharacterInDatabase()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _id);
        foreach (TMP_InputField field in _inputFields)
            form.AddField(field.gameObject.name, field.text);

        WWW www = new WWW("http://localhost/update_character.php", form);
        yield return www;
        if (www.text == "0")
            Debug.Log(_inputFields[0].text + " updated");
        else
            Debug.Log("Character update failed. Error #" + www.text);

        OnCharsheetUpdateButtonPressed?.Invoke();
    }

    private void SetInputFields()
    {
        for (int i = 0; i < _inputFields.Count; i++)
            _inputFields[i].text = _infoList[i];
    }
}
