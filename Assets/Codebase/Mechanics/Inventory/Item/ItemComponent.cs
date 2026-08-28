using UnityEngine;
using System;
using Infrastructure.Interfaces;

namespace Mechanics.Inventory.Item
{
    public class ItemComponent : MonoBehaviour, IInteractable<ItemData>
    {
        [SerializeField] private ItemData data;

        public event Action<ItemData> Interacted;

        public ItemData Interact()
        {
            Interacted?.Invoke(data);
            return data;
        }
    }
}