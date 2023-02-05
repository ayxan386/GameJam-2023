using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [TextArea] [SerializeField] private string approachText;
    [SerializeField] private float duration;

    public virtual void OnUsed()
    {
    }

    public virtual void PreUsed()
    {
        if (TryGetComponent(out MeshRenderer render))
        {
            render.enabled = false;
        }
    }

    public virtual void OnApproach()
    {
        DialogController.Instance.DisplayDialog(approachText, duration);
    }
}