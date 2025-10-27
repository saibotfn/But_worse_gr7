using UnityEngine;

public class triggerEnter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Start swinging");
        }
    }


}
