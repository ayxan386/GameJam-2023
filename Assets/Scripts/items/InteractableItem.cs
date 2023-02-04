using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private string approachText;
    [SerializeField] private float duration;

    public virtual void OnUsed()
    {
    }

    public virtual void OnApproach()
    {
        DialogController.Instance.DisplayDialog(approachText, duration);
    }
}