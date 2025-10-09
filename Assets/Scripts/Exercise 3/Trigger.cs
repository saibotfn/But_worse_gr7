using UnityEngine;
using System.Collections.Generic;

public class Trigger : MonoBehaviour

{
    private bool active = false;
    [SerializeField] private List <Vector3> path = new List <Vector3>() ;
    private int currentTarget = 0;
    [SerializeField] private int speed;


    void OnTriggerEnter(Collider collision)
    {
        active = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!active) { return; }
        if ((path[currentTarget] - transform.position).magnitude <= 0.1f)
        {
            transform.position = path[currentTarget];
            currentTarget++;
        }
        else
        {
            Debug.Log(path.Count);
            Vector3 tempVector = (path[currentTarget] - transform.position).normalized;
            transform.position += tempVector * speed * Time.deltaTime;
        }
    }
}