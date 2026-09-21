using UnityEngine;

public class KeyItem : Interactable
{
    public override string GetInteractionText()
    {
        return "[E] Pick Up Key";
    }

    public override void Interact(
        PlayerInventory inventory)
    {
        if (inventory == null)
        {
            return;
        }

        if (inventory.HasKey)
        {
            return;
        }

        inventory.CollectKey();

        Destroy(gameObject);
    }
}