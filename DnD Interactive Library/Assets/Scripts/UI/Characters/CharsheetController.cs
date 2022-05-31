using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharsheetController : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> _inputFields;

    public void CallCharacterCreation()
    {
        StartCoroutine(CreateCharacter());
    }

    private IEnumerator CreateCharacter()
    {
        WWWForm form = new WWWForm();
        foreach (TMP_InputField field in _inputFields)
            form.AddField(field.gameObject.name, field.text);

        WWW www = new WWW("http://localhost/add_character.php", form);
        yield return www;
        if (www.text == "0")
            Debug.Log(_inputFields[0].text + " added to database");
        else
            Debug.Log("Character creation failed. Error #" + www.text);
    }
}
