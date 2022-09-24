using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    public UnityAction<Item, ItemViewer> OnSellButtonClicked;

    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _sellButton;

    private Item _item;

    public void Render(Item item)
    {
        _item = item;
        _icon.sprite = _item.Icon;
        _name.text = item.Name;
        _price.text = item.Price.ToString();
    }

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (_item.TryGetComponent(out FirstAidKit firstAidKit) == false &&_item.IsBuyed )
        {
            _sellButton.interactable = false;
        }
    }

    private void OnButtonClick()
    {
        OnSellButtonClicked?.Invoke(_item, this);
    }
}
