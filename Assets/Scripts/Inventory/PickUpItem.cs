using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    

    public void OnPickup()
    {
        InventoryManager.AddItem(itemName);
        
    }
}