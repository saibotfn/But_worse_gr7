using UnityEngine;

public class TriggerScript : MonoBehaviour

{
    private bool active = false;
    [SerializeField] private Vector3[] path;


    void OnCollisionEnter(Collision collision)
    {
        active = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!active) { return; }


    }
}
