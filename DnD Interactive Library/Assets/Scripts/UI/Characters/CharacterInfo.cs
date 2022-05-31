using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CharacterInfo : MonoBehaviour
{
    public static Action<int> OnUpdateButtonPressed;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _classAndLevel;
    [SerializeField] private TextMeshProUGUI _race;
    [SerializeField] private TextMeshProUGUI _background;
    [SerializeField] private TextMeshProUGUI _alignment;
    [SerializeField] private TextMeshProUGUI _playerName;

    private string _id;

    public void SetData(string[] data)
    {
        _id = data[0];
        _name.text = data[1];
        _classAndLevel.text = data[2];
        _race.text = data[3];
        _background.text = data[4];
        _alignment.text = data[5];
        _playerName.text = data[6];
    }

    public void DeleteCharacter()
    {
        StartCoroutine(DeleteItem());
    }

    public void OpenCharsheet()
    {
        OnUpdateButtonPressed?.Invoke(int.Parse(_id));
    }

    private IEnumerator DeleteItem()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _id);
        WWW www = new WWW("http://localhost/delete_character.php", form);
        yield return www;
        if (www.text == "0")
            Debug.Log(_name.text + " deleted");
        else
            Debug.Log("Character deletion failed. Error #" + www.text);

        Destroy(gameObject);
    }
}
