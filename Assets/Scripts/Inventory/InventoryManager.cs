using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryManager
{
    // Dictionary zur Speicherung der Anzahl jedes Items im Inventar
    private static Dictionary<string, int> itemCounts = new Dictionary<string, int>();

    // Methode zum Hinzufügen eines Items zum Inventar
    public static void AddItem(string itemName)
    {
        if (itemCounts.ContainsKey(itemName))
        {
            itemCounts[itemName]++;
        }
        else
        {
            itemCounts[itemName] = 1;
        }
    }

    // Methode zum Entfernen eines Items aus dem Inventar
    public static void RemoveItem(string itemName)
    {
        if (itemCounts.ContainsKey(itemName))
        {
            itemCounts[itemName]--;
            if (itemCounts[itemName] <= 0)
            {
                itemCounts.Remove(itemName);
            }
        }
    }

    // Methode zum Überprüfen, ob ein Item im Inventar vorhanden ist
    public static bool HasItem(string itemName)
    {
        return itemCounts.ContainsKey(itemName);
    }

    // Methode zum Abrufen der Anzahl eines bestimmten Items im Inventar
    public static int GetItemCount(string itemName)
    {
        return itemCounts.ContainsKey(itemName) ? itemCounts[itemName] : 0;
    }
}