using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    private List<Quest> quests = new List<Quest>();

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }


    public bool CheckQuestStatus(Quest quest)
    {
        // Überprüfe die Bedingungen der Quest
        bool isCompleted = quest.CheckConditions();

        // Gib den Status der Quest zurück
        return isCompleted;
    }

    // Methode zum Abschließen einer Quest
    public void CompleteQuest(Quest quest, bool collectBounty)
    {
        if (collectBounty)
        {
            quest.ReturnToNPC();
        }
        quest.Complete();
    }
}

