using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BagOfMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.OnMoneyChanged += Change;
    }

    private void OnDisable()
    {
        _player.OnMoneyChanged -= Change;
    }

    private void Change(int value)
    {
        _text.text = value.ToString();
    }
}