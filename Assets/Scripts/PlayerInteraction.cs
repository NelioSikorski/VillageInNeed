using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f;
    public LayerMask interactableLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange, interactableLayer))
        {
            PickupItem pickupItem = hit.collider.GetComponent<PickupItem>();
            InteractableNPC interactableNPC = hit.collider.GetComponent<InteractableNPC>();
            if (pickupItem)
            {
                pickupItem.OnPickup();
            }
            else if (interactableNPC)
            {
                interactableNPC.OnInteract();
            }
        }
    }
}