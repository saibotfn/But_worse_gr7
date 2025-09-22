using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
 
    [SerializeField] private Transform playerBody;

    private void OnLook(InputValue value)


    {
        Vector2 lookInput = value.Get<Vector2>();
        transform.eulerAngles += new Vector3(-lookInput.y, 0,0) * 2f;
        playerBody.eulerAngles += new Vector3(0, lookInput.x, 0) * 2f;
    }

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
