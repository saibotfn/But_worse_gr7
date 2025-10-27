using UnityEngine;

public class boxAnimation : MonoBehaviour
{

    [SerializeField] private new Vector3 movementDirection;


 

    // Update is called once per frame
    void Update()
    {
       gameObject.GetComponent<Rigidbody>().linearVelocity=movementDirection;
   
    }
}
