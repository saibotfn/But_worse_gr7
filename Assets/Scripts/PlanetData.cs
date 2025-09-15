using UnityEngine;

public class PlanetData : MonoBehaviour
{
    public Vector3 rotateSpeed;
    public GameObject rotateAroundObject;
    public Vector3 rotateAroundDirection;
    public float rotateAroundSpeed;
    public Vector3 distanceToCenter; //Distance to object its rotating around
    public int orderInSystem;
    
    public void Move()
    {
        if (rotateAroundObject != null) transform.position = rotateAroundObject.transform.position + distanceToCenter;
    }
}
