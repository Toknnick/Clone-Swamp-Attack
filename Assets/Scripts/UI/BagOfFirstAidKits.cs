using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BagOfFirstAidKits : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.OnHealthChanged += Change;
    }

    private void OnDisable()
    {
        _player.OnHealthChanged -= Change;
    }

    private void Change(int value)
    {
        _text.text = value.ToString();
    }
}
