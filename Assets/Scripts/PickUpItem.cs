using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName;

    // ReSharper disable Unity.PerformanceAnalysis
    public void OnPickup()
    {
        Inventory.AddItem(itemName);
    }
}