using UnityEngine;

public class BOOOM : MonoBehaviour
{
    [SerializeField] private int boomPower;
    [SerializeField] private int boomSize;
    [SerializeField] private int boomUplift;


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("BOOOOM");
        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(boomPower, collision.gameObject.transform.position, boomSize, boomUplift, ForceMode.Impulse);
    }
}
