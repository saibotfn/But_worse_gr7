using UnityEngine;

public class hammerSwing : MonoBehaviour
{
    public GameObject trigger;
    [SerializeField] private new Vector3 swingDirection;
    private Animator animator;

    void awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        { animator.SetTrigger("Start swinging"); }

    }
        // Update is called once per frame
        void Update()
    {
        
        gameObject.GetComponent<Rigidbody>().angularVelocity = swingDirection;

    }
}
 