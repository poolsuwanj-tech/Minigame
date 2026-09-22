using UnityEngine;

public class Door : Interactable
{
    [Header("Door")]
    [SerializeField]
    private GameObject doorObject;

    [Header("Game")]
    [SerializeField]
    private GameManager gameManager;

    private bool completed = false;

    public override string GetInteractionText(
        PlayerInventory inventory)
    {
        if (completed ||
            inventory == null)
        {
            return "";
        }

        PlayerActionMode mode =
            inventory.GetComponent<PlayerActionMode>();

        PlayerAbilities abilities =
            inventory.GetComponent<PlayerAbilities>();

        if (mode == null ||
            abilities == null)
        {
            return "";
        }

        switch (mode.CurrentMode)
        {
            case PlayerActionMode.ActionMode.Key:

                if (inventory.HasKey)
                {
                    return "[E] Unlock Door with Key";
                }

                return "You need a Key";

            case PlayerActionMode.ActionMode.Strength:

                if (abilities.HasAxe)
                {
                    return "[E] Break Door with Axe";
                }

                return "You need an Axe";

            case PlayerActionMode.ActionMode.Lockpicking:

                if (abilities.HasLockpick)
                {
                    return "[E] Pick the Lock";
                }

                return "You need Lockpick Tools";

            case PlayerActionMode.ActionMode.Magic:

                if (abilities.KnowsMagic)
                {
                    return "[E] Cast Dispel";
                }

                return "You need to learn Dispel";
        }

        return "";
    }

    public override void Interact(
        PlayerInventory inventory)
    {
        if (completed ||
            inventory == null)
        {
            return;
        }

        PlayerActionMode mode =
            inventory.GetComponent<PlayerActionMode>();

        PlayerAbilities abilities =
            inventory.GetComponent<PlayerAbilities>();

        if (mode == null ||
            abilities == null)
        {
            return;
        }

        bool success = false;

        switch (mode.CurrentMode)
        {
            case PlayerActionMode.ActionMode.Key:

                if (inventory.HasKey)
                {
                    success = true;

                    Debug.Log(
                        "Door unlocked with Key."
                    );
                }

                break;

            case PlayerActionMode.ActionMode.Strength:

                if (abilities.HasAxe)
                {
                    success = true;

                    Debug.Log(
                        "Door destroyed with Axe."
                    );
                }

                break;

            case PlayerActionMode.ActionMode.Lockpicking:

                if (abilities.HasLockpick)
                {
                    success = true;

                    Debug.Log(
                        "Door lock picked."
                    );
                }

                break;

            case PlayerActionMode.ActionMode.Magic:

                if (abilities.KnowsMagic)
                {
                    success = true;

                    Debug.Log(
                        "Magic seal dispelled."
                    );
                }

                break;
        }

        if (!success)
        {
            return;
        }

        CompleteGame();
    }

    private void CompleteGame()
    {
        completed = true;

        if (doorObject != null)
        {
            doorObject.SetActive(false);
        }

        if (gameManager != null)
        {
            gameManager.WinGame();
        }
    }
}