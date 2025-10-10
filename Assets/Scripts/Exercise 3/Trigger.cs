using UnityEngine;
using System.Collections.Generic;

public class Trigger : MonoBehaviour

{
    private bool active = false;
    [SerializeField] private List <Vector3> path = new List <Vector3>() ;
    private int currentTarget = 0;
    [SerializeField] private int speed;
    [SerializeField] private int rotSpeed;
    [SerializeField] private int desiredRotX;
    [SerializeField] private int fullDesiredRotX;
    private float rotatedAmount = 0f;

    private bool returning = false;


    void OnTriggerEnter(Collider collision)
    {
        active = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if ((path[currentTarget] - transform.position).magnitude <= 0.1f)
            {
                transform.position = path[currentTarget];
                if (currentTarget + 1 >= path.Count)
                {
                    if (rotatedAmount <= desiredRotX)
                    {
                        transform.Rotate(rotSpeed * Time.deltaTime, 0, 0);
                        rotatedAmount += rotSpeed * Time.deltaTime;
                    }
                    else
                    {
                        active = false;
                        returning = true;
                    }
                }
                else { currentTarget++; }
            }
            else
            {
                Vector3 tempVector = (path[currentTarget] - transform.position).normalized;
                transform.position += tempVector * speed * Time.deltaTime;
            }
        }


        if (returning)
        {
            if ((path[currentTarget] - transform.position).magnitude <= 0.1f)
            {
                transform.position = path[currentTarget];
                currentTarget--;
                if(currentTarget < 0) { returning = false;}
            }
            else
            {
                Vector3 tempVector = (path[currentTarget] - transform.position).normalized;
                transform.position += tempVector * speed * Time.deltaTime;
            }

            if (rotatedAmount <= fullDesiredRotX)
            {
                transform.Rotate(rotSpeed * Time.deltaTime, 0, 0);
                rotatedAmount += rotSpeed * Time.deltaTime;
            }
        }
    }
}