using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject endPanel;

    [SerializeField]
    private GameObject crosshair;

    [SerializeField]
    private GameObject interactionText;

    [SerializeField]
    private GameObject modeText;

    [SerializeField]
    private Button restartButton;

    [Header("Player")]
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private PlayerInteraction playerInteraction;

    private bool gameEnded = false;

    private void Start()
    {
        gameEnded = false;

        endPanel.SetActive(false);

        crosshair.SetActive(true);
        interactionText.SetActive(true);
        modeText.SetActive(true);

        Cursor.lockState =
            CursorLockMode.Locked;

        Cursor.visible =
            false;
    }

    private void Update()
    {
        // ตอนจบเกม กด R เพื่อ Restart ได้ทันที
        if (gameEnded &&
            Keyboard.current != null &&
            Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    public void WinGame()
    {
        if (gameEnded)
        {
            return;
        }

        gameEnded = true;

        playerController.enabled = false;
        playerInteraction.enabled = false;

        crosshair.SetActive(false);
        interactionText.SetActive(false);
        modeText.SetActive(false);

        endPanel.SetActive(true);

        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible =
            true;

        Debug.Log("YOU ESCAPED!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}