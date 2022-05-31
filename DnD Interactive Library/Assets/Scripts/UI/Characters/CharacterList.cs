using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterList : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _template;

    private string _dataString;
    private string[] _characters;

    private CharacterInfo[] _spawnedCharacters;

    private void OnEnable()
    {
        StartCoroutine(GetText());
    }

    private void OnDisable()
    {
        foreach (CharacterInfo character in _spawnedCharacters)
            Destroy(character.gameObject);
        InteractionCollider.CanvasIsActive = false;
    }

    private void UpdateText()
    {
        StartCoroutine(GetText());
    }

    public IEnumerator GetText()
    {
        using UnityWebRequest www = UnityWebRequest.Get("http://localhost/get_characters.php");
        yield return www.Send();

        if (www.isNetworkError || www.isHttpError)
            _dataString = www.error;
        else
            _dataString = www.downloadHandler.text;

        _characters = _dataString.Split('*');

        for (int i = 0; i < _characters.Length; i++)
        {
            if (_characters[i] != "")
            {
                string[] characterInfo = _characters[i].Split(';');
                GameObject characterLine = Instantiate(_template);
                characterLine.transform.SetParent(_container.transform);
                characterLine.GetComponent<CharacterInfo>().SetData(characterInfo);
            }
        }

        _spawnedCharacters = FindObjectsOfType<CharacterInfo>();
    }
}
