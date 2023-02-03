using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private string displayName;
    public string DisplayName => displayName;

    public virtual void OnUsed()
    {
        print("Default behavior :)");
    }
}