using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private TextMeshProUGUI interactionText;

    [Header("Settings")]
    [SerializeField]
    private float interactionDistance = 3f;

    private PlayerInventory inventory;

    private void Start()
    {
        inventory =
            GetComponent<PlayerInventory>();

        interactionText.text =
            "";
    }

    private void Update()
    {
        CheckInteraction();
    }

    private void CheckInteraction()
    {
        interactionText.text =
            "";

        Ray ray =
            playerCamera.ViewportPointToRay(
                new Vector3(
                    0.5f,
                    0.5f,
                    0f
                )
            );

        RaycastHit hit;

        bool didHit =
            Physics.Raycast(
                ray,
                out hit,
                interactionDistance
            );

        if (!didHit)
        {
            return;
        }

        Interactable interactable =
            hit.collider.GetComponentInParent
            <Interactable>();

        if (interactable == null)
        {
            return;
        }

        interactionText.text =
            interactable.GetInteractionText();

        if (Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            interactable.Interact(
                inventory
            );
        }
    }
}