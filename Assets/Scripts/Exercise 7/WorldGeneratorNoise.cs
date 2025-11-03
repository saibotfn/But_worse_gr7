using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static Unity.Mathematics.noise;

public class WorldGeneratorNoise : MonoBehaviour
{
    [SerializeField] private Vector3 worldSize;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float frequency;
    [SerializeField] private float caveFrequency;
    [SerializeField] private float threshold;
    [SerializeField] private GameObject[,,] world;
    [SerializeField] private GameObject block;
    [SerializeField] private Material[] mats;

    
    enum Noises { perlin, simplex, cellular };
    [SerializeField] Noises currNoise;

    enum Noisess { perlin, simplex, cellular };
    [SerializeField] Noisess currCaveNoise;


    void Start()
    {
        world = new GameObject[(int)worldSize.x, (int)worldSize.y, (int)worldSize.z];
        generateWorld();
        recalculate2DWorld();
        //recalculate3DWorld();
    }

    
    void Update()
    {
        
    }

    float getNoise3D(float x, float y, float z, float seed, float scale = 1)
    {
        float noiseValue = 0;
        if (currCaveNoise == Noisess.perlin)
        {
            noiseValue = noise.cnoise(new Vector3(x * scale + seed, y * scale + seed, z * scale + seed));

        }
        else if (currCaveNoise == Noisess.simplex)
        {
            noiseValue = noise.snoise(new Vector3(x * scale + seed, y * scale + seed, z * scale + seed));
        }
        else if (currCaveNoise == Noisess.cellular)
        {
            noiseValue = noise.cellular(new Vector3(x * scale + seed, y * scale + seed, z * scale + seed)).x;
        }

        return noiseValue;


    }

    float getNoise2D(float x, float y, float seed, float scale = 1)
    {
        float noiseValue = 0;
        if (currNoise == Noises.perlin)
        {
            noiseValue = noise.cnoise(new Vector2(x * scale + seed, y * scale + seed));
        }
        else if (currNoise == Noises.simplex)
        {
            noiseValue = noise.snoise(new Vector2(x * scale + seed, y * scale + seed));
        }
        else if (currNoise == Noises.cellular)
        {
            noiseValue = noise.cellular(new Vector2(x * scale + seed, y * scale + seed)).x;
        }

        return noiseValue;

    }

    void recalculate2DWorld()
    {
        float newSeed = UnityEngine.Random.Range(0, 10000);
        for (int xCoord = 0; xCoord < worldSize.x; xCoord++)
        {
            for(int zCoord = 0; zCoord < worldSize.z; zCoord++)
            {
                float newNoise = getNoise2D((float) xCoord, (float) zCoord, newSeed, frequency);
                

                for (int yCoord = 0; yCoord < worldSize.y; yCoord++)
                {
                    if(yCoord > newNoise/2 * worldSize.y + worldSize.y/2)
                    {
                        world[xCoord, yCoord, zCoord].SetActive(false);
                    }
                    if(yCoord < newNoise / 2 * worldSize.y + worldSize.y / 2)
                    {
                        world[xCoord, yCoord, zCoord].GetComponent<MeshRenderer>().material = mats[0];
                    }
                    if (yCoord < (newNoise / 2 * worldSize.y + worldSize.y / 2) - 1)
                    {
                        world[xCoord, yCoord, zCoord].GetComponent<MeshRenderer>().material = mats[2];
                    }
                    if (yCoord < (newNoise / 2 * worldSize.y + worldSize.y / 2) - 3)
                    {
                        world[xCoord, yCoord, zCoord].GetComponent<MeshRenderer>().material = mats[1];
                    }
                }
            }
        }
    }

    void recalculate3DWorld()
    {
        float newSeed = UnityEngine.Random.Range(0, 10000);
        for (int xCoord = 0; xCoord < worldSize.x; xCoord++)
        {
            for (int yCoord = 0; yCoord < worldSize.y; yCoord++)

            {
                for (int zCoord = 0; zCoord < worldSize.y; zCoord++)

                {
                    float newNoise = getNoise3D(((float)xCoord / worldSize.x), ((float)yCoord / worldSize.y), ((float)zCoord / worldSize.z), newSeed, caveFrequency);


                    if (newNoise < threshold)
                    {
                        world[xCoord, yCoord, zCoord].SetActive(false);

                    }
                }

            }
        }
    }

    void generateWorld()
    {
        for (int xCoord = 0; xCoord < worldSize.x; xCoord++)
        {
            for (int yCoord = 0; yCoord < worldSize.y; yCoord++)

            {
                for (int zCoord = 0; zCoord < worldSize.z; zCoord++)

                {
                    Vector3 currPos = new Vector3(xCoord * offset.x, yCoord * offset.y, zCoord * offset.z);
                    GameObject currObj = Instantiate(block, currPos, Quaternion.identity);
                    world[xCoord, yCoord, zCoord] = currObj;

                }

            }
        }
    }
}
