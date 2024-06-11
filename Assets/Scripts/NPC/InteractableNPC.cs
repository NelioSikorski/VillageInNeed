using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public string introText;
    public string acceptedText;
    public string completedText;
    public string collectBountyText;
    public bool isInteracted;

    public QuestUI QuestUI;
    public DialogueController dialogueController;
    public Quest quest;

    public enum QuestState
    {
        Intro,
        Accepted,
        Completed,
        CollectBounty
    }

    public QuestState currentQuestState = QuestState.Intro;

    public void OnInteract()
    {
        dialogueController.ShowDialogue();
        switch (currentQuestState)
        {
            case QuestState.Intro:
                dialogueController.SetDialogueText(introText);
                currentQuestState = QuestState.Accepted;
                QuestUI.DisplayQuest(quest);
                break;
            case QuestState.Accepted:
                dialogueController.SetDialogueText(acceptedText);
                if (quest.CheckConditions())
                {
                    currentQuestState = QuestState.Completed;
                }

                break;
            case QuestState.Completed:
                dialogueController.SetDialogueText(completedText);
                
                break;
            case QuestState.CollectBounty:
                dialogueController.SetDialogueText(collectBountyText);
                currentQuestState = QuestState.CollectBounty;
                CompleteQuest();
                break;
        }
        
        isInteracted = true;
        
    }

    public void EndInteract()
    {
        dialogueController.ClearDialogue();
        dialogueController.HideDialogue();
        
    }

    private void CompleteQuest()
    {
        quest.Complete();
        // Hier können Sie Logik zum Sammeln der Belohnung hinzufügen.
        Debug.Log("Quest abgeschlossen und Belohnung eingesammelt.");
    }
}