using System.Collections.Generic;
using VContainer;
using VContainer.Unity;
using Mechanics.Inventory.Item;
using Infrastructure;
using System;

namespace Mechanics.Inventory
{
    public class InventoryStorageService
    {
        private List<ItemData> _items;
        private int _currentItemIndex;
        private int _maxItems;
        
        public ItemData CurrentItem => _currentItemIndex<_items.Count ? 
            _items[_currentItemIndex] : 
            new ItemData{ItemID=ItemData.NULL_ITEM_ID,ItemName=ItemData.NULL_ITEM_NAME};

        public InventoryStorageService(PlayerConfig config)
        {
            _maxItems = config.InventorySize;
            _items = new List<ItemData>();
            _currentItemIndex = 0;
        }

        public bool AddItem(ItemData item)
        {
            if (_items.Count >= _maxItems)
                return false;
            _items.Add(item);
            return true;
        }
        public bool DropItem(ItemData item) => _items.Remove(item);
        public void ChangeItem(int direction)
        {
            if (_items.Count == 0)
            {
                _currentItemIndex = 0;
                return;
            }
            _currentItemIndex = (_currentItemIndex + direction % _items.Count + _items.Count) % _items.Count;
        }
    }
}