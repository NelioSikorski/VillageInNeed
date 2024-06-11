using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAvailabilityCondition : Condition
{
    public string itemName;
    public int requiredAmount;

    public ItemAvailabilityCondition(string itemName, int requiredAmount)
    {
        this.itemName = itemName;
        this.requiredAmount = requiredAmount;
    }

    public override bool IsSatisfied()
    {
        int itemCount = InventoryManager.GetItemCount(itemName);
        return itemCount >= requiredAmount;
    }
}