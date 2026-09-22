using UnityEngine;

public class AbilityItem : Interactable
{
    public enum AbilityType
    {
        Axe,
        Lockpick,
        SpellBook
    }

    [Header("Ability")]
    [SerializeField]
    private AbilityType abilityType;

    [Header("UI")]
    [SerializeField]
    private NotificationUI notificationUI;

    public override string GetInteractionText(
        PlayerInventory inventory)
    {
        switch (abilityType)
        {
            case AbilityType.Axe:
                return "[E] Pick Up Axe";

            case AbilityType.Lockpick:
                return "[E] Pick Up Lockpick";

            case AbilityType.SpellBook:
                return "[E] Read Spell Book";
        }

        return "[E] Interact";
    }

    public override void Interact(
        PlayerInventory inventory)
    {
        if (inventory == null)
        {
            return;
        }

        PlayerAbilities abilities =
            inventory.GetComponent<PlayerAbilities>();

        if (abilities == null)
        {
            return;
        }

        switch (abilityType)
        {
            case AbilityType.Axe:

                abilities.ObtainAxe();

                if (notificationUI != null)
                {
                    notificationUI.ShowMessage(
                        "Obtained Axe!"
                    );
                }

                break;

            case AbilityType.Lockpick:

                abilities.ObtainLockpick();

                if (notificationUI != null)
                {
                    notificationUI.ShowMessage(
                        "Obtained Lockpick Tools!"
                    );
                }

                break;

            case AbilityType.SpellBook:

                abilities.LearnMagic();

                if (notificationUI != null)
                {
                    notificationUI.ShowMessage(
                        "Learned Dispel!"
                    );
                }

                break;
        }

        Destroy(gameObject);
    }
}