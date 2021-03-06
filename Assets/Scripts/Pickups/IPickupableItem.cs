﻿using Assignment.ScriptableObjects;

namespace Assignment.Pickups
{
    public interface IPickupableItem
    {
        ItemStats ItemInfo { get; }
        int Amount { get; }
        void OnItemPicked();
    }
}