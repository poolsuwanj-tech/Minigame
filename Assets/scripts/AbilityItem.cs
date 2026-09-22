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
                break;

            case AbilityType.Lockpick:

                abilities.ObtainLockpick();
                break;

            case AbilityType.SpellBook:

                abilities.LearnMagic();
                break;
        }

        Destroy(gameObject);
    }
}