using UnityEngine;

public class SolarSystemManager : MonoBehaviour
{
    [SerializeField] private PlanetData[] SolarSystem = new PlanetData[0];
    void Awake()
    {
        foreach(PlanetData obj in SolarSystem)
        {
            obj.Move();
        }
    }

    
    private void Update()
    {
        for (int i = 0; i < SolarSystem.Length;  i++)
        {
            PlanetData obj = SolarSystem[i];
            obj.gameObject.transform.RotateAround(obj.rotateAroundObject.transform.position, obj.rotateAroundDirection, obj.rotateAroundSpeed);

            if (i + 1 >= SolarSystem.Length) return;

            PlanetData moon = SolarSystem[i + 1];
            moon.gameObject.transform.RotateAround(obj.rotateAroundObject.transform.position, obj.rotateAroundDirection, obj.rotateAroundSpeed);
        }
    }
}
