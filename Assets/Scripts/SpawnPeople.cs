using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class works similarly to SpawnMaskGel class. It instantiates people in random x positions on the street.

//for peoplemanager in player
public class SpawnPeople : MonoBehaviour
{
    public GameObject[] peoplePrefabs;
    private List<GameObject> activePeople = new List<GameObject>();
    private int lastPrefabIndex = 0;
    private int waitTime = 10;
    private int prefInd;
    private float currentZ;
    private int maxPeopleNumber = 25;
    private int activePeopleNumber = 0;
    public float randomPos = 10f;
    private float lastPrefabPos = 0;
    private float minDistance = 0.8f;
    //private Transform playerTransform;
    void Start()
    {
        currentZ = transform.position.z;
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        //currentZ = transform.position.z;
        if((currentZ + waitTime) < transform.position.z + GameData.difficultyLevel)
        {
            prefInd = RandomPrefabIndex();
            randomPos = RandomPositon();
            SpawnThePeople(prefInd, new Vector3(randomPos, transform.position.y, transform.position.z));
            activePeopleNumber++;
            currentZ = transform.position.z;
            if (activePeopleNumber >= maxPeopleNumber)
            {
                DeletePeople();
                activePeopleNumber--;
            }
        }

        //delete prefabs
    }
    private void SpawnThePeople(int prefabIndex,Vector3 pos)
    {
        //currentX = transform.position.x;
       // transform.position = new Vector3(randomPos - currentX, transform.position.y, transform.position.z);
        GameObject go;
        //pos = 
        go = Instantiate(peoplePrefabs[prefabIndex],pos, Quaternion.Euler(0,180,0)) as GameObject;
        go.transform.SetParent(transform);
        //go.transform.position = new Vector3(randomPos - transform.position.x,transform.position.y,transform.position.z);

        activePeople.Add(go);
    }
    private void DeletePeople()
    {
        Destroy(activePeople[0]);
        activePeople.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (peoplePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, peoplePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
    private float RandomPositon()
    {
        randomPos = lastPrefabPos;
        while (Math.Abs(lastPrefabPos - randomPos) < minDistance)
        {
            randomPos = UnityEngine.Random.Range(-2.3f, 2.3f);
        }
        lastPrefabPos = randomPos;
        return randomPos;
    }
}
