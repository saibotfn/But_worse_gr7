using UnityEngine;
using UnityEngine.AI;

public class PewPew : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform player;
    public float[] enemyHealth;
    [SerializeField] int damage = 1;
    [SerializeField] private int boomPower = 100;
    [SerializeField] private int boomSize = 100;
    [SerializeField] private int boomUplift = 100;



    void Update()
    {
        for (int i = 0; i < enemy.Length; i++)
        {

            if (enemy[i] == null) continue;
            enemy[i].GetComponent<NavMeshAgent>().SetDestination(player.position);


            if (enemyHealth[i] <= 1f)
            {
                enemy[i].GetComponent<ParticleSystem>().Play();
            }

            if (enemyHealth[i] <= 0f)
            {
                enemy[i].GetComponent<NavMeshAgent>().enabled = false;
                //enemy[i].GetComponent<Rigidbody>().enabled = true;
                enemy[i].GetComponent<Rigidbody>().AddExplosionForce(
                    Random.Range(boomPower - 5, boomPower + 5),
                    enemy[i].gameObject.transform.position,
                    Random.Range(boomSize - 5, boomSize + 5),
                    Random.Range(boomUplift - 5, boomUplift + 5),
                    ForceMode.Impulse);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(player.position, player.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    for (int i = 0; i < enemy.Length; i++)
                    {
                        if (enemy[i] == null) continue;
                        if (hit.collider.gameObject == enemy[i])
                        {
                            enemyHealth[i] -= damage;
                            enemy[i].GetComponent<NavMeshAgent>().SetDestination(enemy[i].transform.position);
                            break;
                        }
                    }
                }

            }
        }
    }

}
