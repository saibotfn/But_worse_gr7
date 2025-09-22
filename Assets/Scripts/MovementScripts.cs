using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScripts : MonoBehaviour
{

    private Vector2 moveInput;

    private void OnMove(InputValue value)

  {
    moveInput = value.Get<Vector2>();

  }  

    void Update()
        {
            Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
            transform.Translate(move * Time.deltaTime * 5f);
        }


}
