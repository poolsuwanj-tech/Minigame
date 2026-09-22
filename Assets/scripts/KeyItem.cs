using UnityEngine;

public class KeyItem : Interactable
{
    [Header("UI")]
    [SerializeField]
    private NotificationUI notificationUI;

    public override string GetInteractionText(
        PlayerInventory inventory)
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

        if (notificationUI != null)
        {
            notificationUI.ShowMessage(
                "Obtained Key!"
            );
        }

        Destroy(gameObject);
    }
}