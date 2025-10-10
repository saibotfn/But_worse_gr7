using UnityEngine;

public class BALLS : MonoBehaviour
{
    private bool balls = false;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int ballAmount;
    [SerializeField] private Vector3[] spawnZone;

    void OnCollisionEnter(Collision collision)
    {
        if (balls) { return; }
        if (collision.gameObject.tag != "Player") { return; }
        balls = true;
        for (int i = 0; i < ballAmount; i++)
        {
            Instantiate(ballPrefab, new Vector3(Random.Range(spawnZone[0].x, spawnZone[1].x), Random.Range(spawnZone[0].y, spawnZone[1].y), Random.Range(spawnZone[0].z, spawnZone[1].z)), Quaternion.identity);
        }
    }
}
