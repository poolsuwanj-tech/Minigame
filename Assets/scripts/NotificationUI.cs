using UnityEngine;
using TMPro;
using System.Collections;

public class NotificationUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI notificationText;

    [Header("Settings")]
    [SerializeField]
    private float showTime = 1.5f;

    private Coroutine currentMessage;

    private void Start()
    {
        if (notificationText != null)
        {
            notificationText.text = "";
        }
    }

    public void ShowMessage(string message)
    {
        if (notificationText == null)
        {
            return;
        }

        if (currentMessage != null)
        {
            StopCoroutine(currentMessage);
        }

        currentMessage =
            StartCoroutine(
                ShowMessageRoutine(message)
            );
    }

    private IEnumerator ShowMessageRoutine(
        string message)
    {
        notificationText.text =
            message;

        yield return
            new WaitForSeconds(showTime);

        notificationText.text =
            "";

        currentMessage = null;
    }
}