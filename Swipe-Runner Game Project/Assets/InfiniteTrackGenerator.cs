using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTrackGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform playerTransform;
    public float platformLength = 10f;
    public int initialPlatforms = 10;
    private float spawnZ = 0f;
    private float safeZone = 50f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activePlatforms;

    void Start()
    {
        activePlatforms = new List<GameObject>();
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - initialPlatforms * platformLength))
        {
            SpawnPlatform();
            DeletePlatform();
        }
    }

    private void SpawnPlatform(int prefabIndex = -1)
    {
        GameObject obj;
        obj = Instantiate(platformPrefab) as GameObject;
        obj.transform.SetParent(transform);
        obj.transform.position = Vector3.forward * spawnZ;
        spawnZ += platformLength;
        activePlatforms.Add(obj);
    }

    private void DeletePlatform()
    {
        Destroy(activePlatforms[0]);
        activePlatforms.RemoveAt(0);
    }
}

