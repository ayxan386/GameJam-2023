using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator playerAnimator;
    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (GlobalStateManager.FullscreenCanvas) return;
        var inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.rotation * inputVector;

        characterController.SimpleMove(inputVector * speed);
        playerAnimator.SetBool("walking", inputVector.magnitude > 0);
    }
}