using UnityEngine;

public class BOOOM : MonoBehaviour
{
    [SerializeField] private int boomPower;
    [SerializeField] private int boomSize;
    [SerializeField] private int boomUplift;


    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(
            Random.Range(boomPower - 5, boomPower + 5), 
            collision.gameObject.transform.position, 
            Random.Range(boomSize - 5, boomSize + 5), 
            Random.Range(boomUplift - 5, boomUplift + 5), 
            ForceMode.Impulse);
    }
}
