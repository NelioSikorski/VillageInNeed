using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    // Referenz auf das TextMeshPro-Objekt
    public TextMeshProUGUI textMeshPro;

    // Referenz auf das Panel
    public GameObject panel;

    // Methode zum Setzen des Textes im TextMeshPro-Objekt
    public void SetDialogueText(string dialogue)
    {
        textMeshPro.text = dialogue;
    }

    // Methode zum Ausblenden des Panels und des Textes
    public void HideDialogue()
    {
        panel.SetActive(false);
        textMeshPro.enabled = false;
    }

    // Methode zum Einblenden des Panels und des Textes
    public void ShowDialogue()
    {
        panel.SetActive(true);
        textMeshPro.enabled = true;
    }

    // Methode zum Löschen des Textes im TextMeshPro-Objekt
    public void ClearDialogue()
    {
        textMeshPro.text = "";
    }
}