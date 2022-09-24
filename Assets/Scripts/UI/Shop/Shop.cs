using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private Player _player;
    [SerializeField] private ItemViewer _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            AddItems(_items[i]);
        }
    }

    private void AddItems(Item item)
    {
        var viewer = Instantiate(_template, _itemContainer.transform);
        viewer.OnSellButtonClicked += OnSellButtonClick;
        viewer.Render(item);
    }

    private void OnSellButtonClick(Item item, ItemViewer viewer)
    {
        TrySellItem(item, viewer);
    }

    private void TrySellItem(Item item, ItemViewer viewer)
    {
        if (item.Price <= _player.Money)
        {
            if (item.TryGetComponent(out FirstAidKit firstAidKit) == false)
                viewer.OnSellButtonClicked -= OnSellButtonClick;

            _player.BuyItem(item);
            item.Sell();
        }
    }
}
