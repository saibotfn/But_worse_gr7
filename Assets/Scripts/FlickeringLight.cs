using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light lightSource;
    public float minTime = 0.5f;
    public float maxTime = 1.5f;
    
    public float flickerSpeed = 0.1f;
    private float flickerTimer = 0f;

    private float lastFlicker = 0f;

    void Start()
    {
        lightSource = GetComponent<Light>();
       
    }

    void Update()
    {


        if (flickerTimer <= 0f)
        {
            lightSource.enabled = false;
            flickerTimer = Random.Range(minTime, maxTime);
            lastFlicker = flickerSpeed;
        }
        else
        {
            flickerTimer -= Time.deltaTime;
            lastFlicker -= Time.deltaTime;
        }

        if (lastFlicker <= 0f)
        {
            lightSource.enabled = true;
        }
    
        
    }





}
