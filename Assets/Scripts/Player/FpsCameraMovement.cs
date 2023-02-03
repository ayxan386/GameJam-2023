using UnityEngine;

public class FpsCameraMovement : MonoBehaviour
{
    [SerializeField] private Vector2 mouseSensitivity;
    [SerializeField] private Vector2 angleLimit;
    private float angleX;
    private Vector3 initialAngles;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        initialAngles = transform.localEulerAngles;
        angleX = initialAngles.x;
    }

    void Update()
    {
        if (GlobalStateManager.PlayingMiniGame) return;
        var mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        transform.parent.Rotate(0, mouseMovement.x * mouseSensitivity.x * Time.deltaTime, 0);

        angleX = Mathf.Clamp(angleX - mouseMovement.y * mouseSensitivity.y * Time.deltaTime, angleLimit.x,
            angleLimit.y);
        transform.localRotation = Quaternion.Euler(angleX, initialAngles.y, initialAngles.z);
    }
}