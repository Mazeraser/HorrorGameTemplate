using System;

namespace Mechanics.Inventory.Item
{
    [System.Serializable]
    public struct ItemData
    {
        public const int NULL_ITEM_ID = -1;
        public int ItemID;
        public const string NULL_ITEM_NAME = "";
        public string ItemName;
    }
}