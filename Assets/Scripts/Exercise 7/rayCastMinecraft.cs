using UnityEngine;

public class rayCastMinecraft : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
