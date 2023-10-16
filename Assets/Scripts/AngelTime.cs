using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

//This class is written for when the player is passed over an angel. In this case, it spawns some
//masks and clouds in the sky.

//for "AngelTime" in main scene
public class AngelTime : MonoBehaviour
{
    private Transform firstTran;
    public GameObject mask, cloud;
    public static bool spawnOnce = false;
    private float randomPos, zPos;
    private int i = 0;

    // Update is called once per frame
    void Update()
    {
        if(PlayerMotor.becomeAngel == true && spawnOnce == false)
        {
            spawnOnce = true;
            firstTran = GameObject.FindGameObjectWithTag("Player").transform;
            spawnMask(firstTran);
            spawnClouds(firstTran);
        }

        if (PlayerMotor.destAngMask == true && spawnOnce == true)
        {
            GameObject[] masks = GameObject.FindGameObjectsWithTag("AngelMasks");
            foreach (GameObject mas in masks)
                GameObject.Destroy(mas);

            GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
            foreach (GameObject cl in clouds)
                GameObject.Destroy(cl);

            spawnOnce = false;
            PlayerMotor.destAngMask = false;
        }
    }
    private void spawnMask(Transform trans)
    {
        zPos = trans.position.z;
        while(i < 10)
        {
            randomPos = UnityEngine.Random.Range(-2.3f, 2.3f);
            GameObject go;
            go = Instantiate(mask, new Vector3(randomPos, 4.8f, zPos), Quaternion.identity) as GameObject;
            go.transform.SetParent(transform);
            zPos += 14;
            i++;
        }
        i = 0;
    }
    private void spawnClouds(Transform trans)
    {
        GameObject gob;
        gob = Instantiate(cloud, new Vector3(0, 0.5f, trans.position.z), Quaternion.identity) as GameObject;
        gob.transform.SetParent(transform);
    }
}
