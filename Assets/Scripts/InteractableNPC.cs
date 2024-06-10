using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public string npcName;

    public void OnInteract()
    {
        Debug.Log("Interacting with NPC: " + npcName);
        
        
    }
}

