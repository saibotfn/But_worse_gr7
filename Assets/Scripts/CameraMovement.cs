using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
 
    [SerializeField] private Transform playerBody;
    private float rotX;
    private float rotY;

    private void OnLook(InputValue value)
    {
        Vector2 lookInput = value.Get<Vector2>();
        rotX += lookInput.x;
        rotY += lookInput.y;

        rotY = Mathf.Clamp(rotY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(-rotY, 0f, 0f);
        playerBody.localRotation = Quaternion.Euler(0f, rotX, 0f);
        
    }

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
