using UnityEngine;
using UnityEngine.AI;

public class enemyBehavior : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform player;
    public float[] enemyHealth;



    void Update()
    {
        for(int i = 0; i<enemy.Length; i++)
        {

            if(enemy[i] == null) continue;
            enemy[i].GetComponent<NavMeshAgent>().SetDestination(player.position);


            if(enemyHealth[i] <= 1f)
            {
                enemy[i].GetComponent<ParticleSystem>().Play();
            }

            if(enemyHealth[i] <= 0f)
            {
                GameObject.Destroy(enemy[i]);
            }
        }

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
                        enemyHealth[i] -= Time.deltaTime;
                        enemy[i].GetComponent<NavMeshAgent>().SetDestination(enemy[i].transform.position);
                        break;
                    }
                }
            }

        }

    }
}
