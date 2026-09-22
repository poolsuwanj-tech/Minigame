using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract string GetInteractionText(
        PlayerInventory inventory
    );

    public abstract void Interact(
        PlayerInventory inventory
    );
}