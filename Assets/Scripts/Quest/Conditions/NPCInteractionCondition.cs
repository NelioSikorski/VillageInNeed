using UnityEngine;

public class NPCInteractionCondition : Condition
{
    public InteractableNPC npc;
    public bool collectBounty;

    public NPCInteractionCondition(InteractableNPC npc)
    {
        this.npc = npc;
    }

    public override bool IsSatisfied()
    {
        return npc.isInteracted;
    }
}

