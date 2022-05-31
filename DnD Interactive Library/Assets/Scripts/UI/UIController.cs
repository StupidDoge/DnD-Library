using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static Action<int> OnCharsheetOpened;

    [SerializeField] private GameObject _charsheetUpdate;
    [SerializeField] private GameObject _characterList;

    private void OnEnable()
    {
        CharacterInfo.OnUpdateButtonPressed += OpenCharsheet;
        CharacterUpdateCharsheet.OnCharsheetUpdateButtonPressed += OpenCharacterList;
    }

    private void OnDisable()
    {
        CharacterInfo.OnUpdateButtonPressed -= OpenCharsheet;
        CharacterUpdateCharsheet.OnCharsheetUpdateButtonPressed -= OpenCharacterList;
    }

    private void OpenCharsheet(int id)
    {
        _charsheetUpdate.SetActive(true);
        _characterList.SetActive(false);
        OnCharsheetOpened?.Invoke(id);
        InteractionCollider.CanvasIsActive = true;
    }

    private void OpenCharacterList()
    {
        _charsheetUpdate.SetActive(false);
        _characterList.SetActive(true);
        InteractionCollider.CanvasIsActive = true;
    }
}
