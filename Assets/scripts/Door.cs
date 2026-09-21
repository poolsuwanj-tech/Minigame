using UnityEngine;

public class Door : Interactable
{
    [Header("Door")]
    [SerializeField]
    private GameObject doorObject;

    [Header("Game")]
    [SerializeField]
    private GameManager gameManager;

    private bool isOpen = false;

    public override string GetInteractionText()
    {
        if (isOpen)
        {
            return "";
        }

        return "[E] Open Door";
    }

    public override void Interact(
        PlayerInventory inventory)
    {
        if (isOpen)
        {
            return;
        }

        if (inventory == null)
        {
            return;
        }

        // ยังไม่มีกุญแจ
        if (!inventory.HasKey)
        {
            Debug.Log("Door is locked.");

            return;
        }

        // มีกุญแจแล้ว
        isOpen = true;

        // ทำให้ประตูหายทันที
        if (doorObject != null)
        {
            doorObject.SetActive(false);
        }

        // ขึ้นหน้าจบเกมทันที
        if (gameManager != null)
        {
            gameManager.WinGame();
        }
    }
}