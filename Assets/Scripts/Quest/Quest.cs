using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questName;
    public string questDescription;
    public bool getBounty;
    public List<Condition> conditions; // Liste von Bedingungen
    public List<Quest> subQuests;
    private bool isCompleted = false;
    public bool isActive = false;

    public bool CheckConditions()
    {
        foreach (Condition condition in conditions)
        {
            if (!condition.IsSatisfied())
            {
                return false;
            }
        }

        foreach (Quest subQuest in subQuests)
        {
            if (!subQuest.CheckConditions())
            {
                return false;
            }
        }

        return true;
    }

    public void Complete()
    {
        isCompleted = true;
    }

    public void ReturnToNPC()
    {
        Debug.Log("Quest " + questName + " wurde abgeschlossen. Zurück zum NPC.");
    }
}