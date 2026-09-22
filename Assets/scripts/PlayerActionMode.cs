using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerActionMode : MonoBehaviour
{
    public enum ActionMode
    {
        Key,
        Strength,
        Lockpicking,
        Magic
    }

    [Header("Current Mode")]
    [SerializeField]
    private ActionMode currentMode =
        ActionMode.Key;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI modeText;

    public ActionMode CurrentMode
    {
        get
        {
            return currentMode;
        }
    }

    private void Start()
    {
        UpdateModeText();
    }

    private void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            ChangeMode(
                ActionMode.Key
            );
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ChangeMode(
                ActionMode.Strength
            );
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ChangeMode(
                ActionMode.Lockpicking
            );
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            ChangeMode(
                ActionMode.Magic
            );
        }
    }

    public void ChangeMode(
        ActionMode newMode)
    {
        currentMode =
            newMode;

        UpdateModeText();

        Debug.Log(
            "Mode: " +
            currentMode
        );
    }

    private void UpdateModeText()
    {
        if (modeText == null)
        {
            return;
        }

        switch (currentMode)
        {
            case ActionMode.Key:

                modeText.text =
                    "[1] KEY";

                break;

            case ActionMode.Strength:

                modeText.text =
                    "[2] STRENGTH";

                break;

            case ActionMode.Lockpicking:

                modeText.text =
                    "[3] LOCKPICK";

                break;

            case ActionMode.Magic:

                modeText.text =
                    "[4] MAGIC";

                break;
        }
    }
}