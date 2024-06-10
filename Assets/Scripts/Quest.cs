using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    // Eine Liste von Gegenständen, die für die Quest benötigt werden
    private Dictionary<string, int> requiredItems = new Dictionary<string, int>
    {
        { "Coal", 1 },
        { "Iron", 1 }
    };

    // Überprüft, ob alle erforderlichen Gegenstände im Inventar vorhanden sind
    public bool IsQuestComplete()
    {
        foreach (var item in requiredItems)
        {
            if (Inventory.GetItemCount(item.Key) < item.Value)
            {
                return false;
            }
        }
        return true;
    }

    // Gibt den Fortschritt der Quest als Text zurück
    public string GetQuestProgress()
    {
        List<string> progress = new List<string>();
        foreach (var item in requiredItems)
        {
            int itemCount = Inventory.GetItemCount(item.Key);
            progress.Add($"{item.Key}: {itemCount}/{item.Value}");
        }
        return string.Join(", ", progress);
    }

    // Ein Beispiel, um den Fortschritt im Debug-Log anzuzeigen
    public void CheckQuestStatus()
    {
        if (IsQuestComplete())
        {
            Debug.Log("Die Quest ist abgeschlossen!");
        }
        else
        {
            Debug.Log("Quest Fortschritt: " + GetQuestProgress());
        }
    }
}