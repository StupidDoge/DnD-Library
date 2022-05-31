using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rollResult;
    [SerializeField] private int _diceType;

    public void RollDice()
    {
        int value = Random.Range(1, _diceType + 1);
        _rollResult.text = value.ToString();
    }
}
