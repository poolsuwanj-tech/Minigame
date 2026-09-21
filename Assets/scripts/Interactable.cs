using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract string GetInteractionText();

    public abstract void Interact(
        PlayerInventory inventory
    );
}