using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    private static Dictionary<string, int> questItems = new Dictionary<string, int>
    {
        { "Healroot", 0 },
        { "Axe", 0 },
        { "Iron", 0 },
        { "Coal", 0 },
        { "Corn", 0 },
        { "Flower", 0 },
        { "Shield", 0 },
        { "Sword", 0 },
        { "Wood", 0 },
        { "Lumber", 0 },
        { "Bow", 0 }
    };

    public static void AddItem(string itemName)
    {
        foreach (var key in questItems.Keys)
        {
            if (itemName.Contains(key))
            {
                questItems[key]++;
            }
        }
    }

    
    public static bool HasQuestItem(string itemName)
    {
        return questItems.ContainsKey(itemName) && questItems[itemName] > 0;
    }
    
    public static int GetItemCount(string itemName)
    {
        return questItems.ContainsKey(itemName) ? questItems[itemName] : 0;
    }


    public static Dictionary<string, int> GetAllQuestItems()
    {
        return new Dictionary<string, int>(questItems);
    }
}
