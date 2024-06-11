using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Quest quest = (Quest)target;

        if (GUILayout.Button("Add Condition"))
        {
            quest.conditions.Add(null); // Füge eine neue Bedingung hinzu
        }
    }
}