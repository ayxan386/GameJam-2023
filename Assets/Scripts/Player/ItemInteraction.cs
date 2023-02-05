using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask interactionLayer;

    [FormerlySerializedAs("interactionPoint")] [SerializeField]
    private Transform topInteractionPoint;

    [SerializeField] private Transform middleInteractionPoint;
    [SerializeField] private Transform lowInteractionPoint;
    [SerializeField] private GameObject canGrabbedRef;
    [SerializeField] private Animator animator;

    private InteractableItem lastItem;

    void Update()
    {
        if (GlobalStateManager.FullscreenCanvas) return;
        var grabDirection = "";
        if (!CheckInteraction(topInteractionPoint))
        {
            if (!CheckInteraction(middleInteractionPoint))
            {
                if (CheckInteraction(lowInteractionPoint))
                {
                    grabDirection = "grabBottom";
                }
            }
            else
            {
                grabDirection = "grabMiddle";
            }
        }
        else
        {
            grabDirection = "grabTop";
        }


        if (lastItem != null && Input.GetButtonDown("Fire1"))
        {
            if (lastItem is PanelActivatingItem)
            {
                lastItem.OnUsed();
            }
            else
            {
                animator.SetTrigger(grabDirection);
                lastItem.PreUsed();
                StartCoroutine(WaitForAnimation(lastItem));
            }
        }
    }

    private bool CheckInteraction(Transform interactionPoint)
    {
        var colliders = Physics.OverlapSphere(interactionPoint.position, maxDistance, interactionLayer);
        if (colliders != null
            && colliders.Length > 0
            && colliders[0].TryGetComponent(out InteractableItem item))
        {
            item.OnApproach();
            lastItem = item;
            return true;
        }

        lastItem = null;
        canGrabbedRef?.SetActive(false);

        return false;
    }

    private IEnumerator WaitForAnimation(InteractableItem item)
    {
        GlobalStateManager.CanMove = false;
        yield return new WaitForSeconds(2f);
        yield return new WaitWhile(() => animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Grab"));
        item.OnUsed();
        GlobalStateManager.CanMove = true;
    }
}