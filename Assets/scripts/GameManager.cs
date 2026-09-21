using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject endPanel;

    [SerializeField]
    private GameObject crosshair;

    [SerializeField]
    private GameObject interactionText;

    [Header("Player")]
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private PlayerInteraction playerInteraction;

    private bool gameEnded = false;

    private void Start()
    {
        endPanel.SetActive(false);
    }

    public void WinGame()
    {
        if (gameEnded)
        {
            return;
        }

        gameEnded = true;

        endPanel.SetActive(true);

        crosshair.SetActive(false);

        interactionText.SetActive(false);

        playerController.enabled = false;

        playerInteraction.enabled = false;

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
}