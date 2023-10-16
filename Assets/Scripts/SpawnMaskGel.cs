using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class spawns the masks on the street. After some meters passed by the player, it
//instantiates a mask in a random x position on the street.At the same time, it destroys one
//of the previous masks, if the number of active masks exceeds a certain number.Also, if the
//player passes over a mask, it destroys the mask and decreases the number of active masks.

//for MGManager
public class SpawnMaskGel : MonoBehaviour
{
    public GameObject MGPrefabs;
    private Transform playerTransform;
    private List<GameObject> activeMGs = new List<GameObject>();
    private int prefInd;
    private float currentZ = 20;
    private int maxMGNumber = 20;
    private int activeMGNumber = 0;
    private float randomPos = 10f;
    public AudioSource butt;
    public AudioClip Aud;

    //private Transform playerTransform;
    void Start()
    {
        currentZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //currentZ = transform.position.z;
        if (playerTransform.position.z > currentZ)
        {
            randomPos = RandomPositon();
            //currentZ += 10;
            SpawnThePeople(prefInd, new Vector3(randomPos, 0.5f , playerTransform.position.z + 40));
            activeMGNumber++;
            if (activeMGNumber >= maxMGNumber)
            {
                DeleteMG();
                activeMGNumber--;
            }
            currentZ += 20;
        }
        if(CollectMG.delMG == true)
        {
            butt.PlayOneShot(Aud);
            DeleteMG();
            activeMGNumber--;
            CollectMG.delMG = false;
        }

        //delete prefabs
    }
    private void SpawnThePeople(int prefabIndex, Vector3 pos)
    {
        //currentX = transform.position.x;
        // transform.position = new Vector3(randomPos - currentX, transform.position.y, transform.position.z);
        GameObject go;
        //pos = 
        go = Instantiate(MGPrefabs, pos, Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        //go.transform.position = new Vector3(randomPos - transform.position.x,transform.position.y,transform.position.z);

        activeMGs.Add(go);
    }
    public void DeleteMG()
    {
        Destroy(activeMGs[0]);
        activeMGs.RemoveAt(0);
    }
    private float RandomPositon()
    {
        randomPos = UnityEngine.Random.Range(-2.3f, 2.3f);
        return randomPos;
    }
}
