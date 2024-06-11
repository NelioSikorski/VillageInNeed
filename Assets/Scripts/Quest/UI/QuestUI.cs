using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public Quest mainQuest;
    public TextMeshProUGUI questItemPrefab;
    public Transform questListParent;

    private void Start()
    {
        questItemPrefab.text = "Aktuelle Quest:" + "\n" + "Frage eine Person nach dem Weg";
    }

    public void DisplayQuest(Quest quest)
    {
        
        questItemPrefab.text = "Aktuelle Quest:" + "\n" + quest.questName + "\n" + quest.questDescription;
        
    }
}