using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool hasKey = false;

    public bool HasKey
    {
        get
        {
            return hasKey;
        }
    }

    public void CollectKey()
    {
        hasKey = true;

        Debug.Log("Player collected the key.");
    }
}