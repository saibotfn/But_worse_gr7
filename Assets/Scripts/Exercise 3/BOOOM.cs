using UnityEngine;

public class BOOOM : MonoBehaviour
{
    [SerializeField] private int boomPower;
    [SerializeField] private int boomSize;
    [SerializeField] private int boomUplift;


    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(
            Random.RandomRange(boomPower - 5, boomPower + 5), 
            collision.gameObject.transform.position, 
            Random.RandomRange(boomSize - 5, boomSize + 5), 
            Random.RandomRange(boomUplift - 5, boomUplift + 5), 
            ForceMode.Impulse);
    }
}
