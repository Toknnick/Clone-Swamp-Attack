using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed = false;

    public Sprite Icon => _icon;
    public string Name => _name;
    public int Price => _price;
    public bool IsBuyed => _isBuyed;

    public void Sell()
    {
        if (TryGetComponent(out FirstAidKit firstAidKit) == false)
        {
            _isBuyed = true;
        }
    }
}
