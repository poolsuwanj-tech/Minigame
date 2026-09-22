using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [Header("Unlocked Abilities")]

    [SerializeField]
    private bool hasAxe = false;

    [SerializeField]
    private bool hasLockpick = false;

    [SerializeField]
    private bool knowsMagic = false;

    public bool HasAxe
    {
        get
        {
            return hasAxe;
        }
    }

    public bool HasLockpick
    {
        get
        {
            return hasLockpick;
        }
    }

    public bool KnowsMagic
    {
        get
        {
            return knowsMagic;
        }
    }

    public void ObtainAxe()
    {
        hasAxe = true;

        Debug.Log(
            "Axe obtained."
        );
    }

    public void ObtainLockpick()
    {
        hasLockpick = true;

        Debug.Log(
            "Lockpick obtained."
        );
    }

    public void LearnMagic()
    {
        knowsMagic = true;

        Debug.Log(
            "Dispel learned."
        );
    }
}