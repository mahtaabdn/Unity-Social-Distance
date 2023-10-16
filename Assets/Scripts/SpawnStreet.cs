using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class spawns the street blocks after the certain meters passed by the player and delete
//the passed street block.The street blocks which are instantiated, are chosen randomly.

//for StreetManager
public class SpawnStreet : MonoBehaviour
{
    public GameObject[] streetPrefabs;
    private Transform playerTransform;
    private float spawnZ = -5.0f;
    private float streetLength = 32.0f;
    private int numberOnScreen = 5;
    private List<GameObject> activeStreets = new List<GameObject>();
    private float safeZone = 40.0f;
    private int lastPrefabIndex = 0;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < numberOnScreen; i++)
        {
            if (i < 1)
            {
                SpawnTheStreet(0);
            }
            else
            {
                SpawnTheStreet();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > spawnZ - numberOnScreen * streetLength)
        {
            SpawnTheStreet();
            DeleteStreet();
        }
    }
    private void SpawnTheStreet(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(streetPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(streetPrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += streetLength;
        activeStreets.Add(go);
    }
    private void DeleteStreet()
    {
        Destroy(activeStreets[0]);
        activeStreets.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (streetPrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, streetPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
