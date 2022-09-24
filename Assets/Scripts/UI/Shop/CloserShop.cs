using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloserShop : MonoBehaviour
{
    [SerializeField] private GameObject _shop;

    public void CloseShop()
    {
        _shop.SetActive(false);
    }
}
