using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
//This class spawns the angels on the street. After some meters passed by the player, it
//instantiates an angel in a random x position on the street.

//for AngelManager
public class SpawnAngel : MonoBehaviour
{
    public GameObject AngelPrefab;
    private Transform playerTransform;
    private float currentZ = 250;
    private float randomPos = 10f;
    public AudioSource butt;
    public AudioClip Aud;
    public Animator ani;
    public static bool fly = false;
    // Start is called before the first frame update
    void Start()
    {
        currentZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMotor.flyEnd == true)
        {
            ani.SetTrigger("flyEnd");
            PlayerMotor.flyEnd = false;
            PlayerMotor.destAngMask = true;
        }
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //currentZ = transform.position.z;
        if (playerTransform.position.z > currentZ)
        {
            randomPos = RandomPositon();
            //currentZ += 10;
            SpawnThePeople(new Vector3(randomPos, 0.8f, playerTransform.position.z + 250));
            currentZ += 250;
        }
        if(CollectAngel.angelTime == true)
        {
            butt.PlayOneShot(Aud);
            if (PlayerMotor.downingTime == false)
            {
                ani.SetTrigger("flyTime");
            }
            
            //player goes up
            fly = true;

            PlayerMotor.verticalVeloity = 1;
            CollectAngel.angelTime = false;
        }

        //delete prefabs
    }
    private void SpawnThePeople(Vector3 pos)
    {
        //currentX = transform.position.x;
        // transform.position = new Vector3(randomPos - currentX, transform.position.y, transform.position.z);
        GameObject go;
        //pos = 
        go = Instantiate(AngelPrefab, pos, Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        //go.transform.position = new Vector3(randomPos - transform.position.x,transform.position.y,transform.position.z);

    }

    private float RandomPositon()
    {
        randomPos = UnityEngine.Random.Range(-2.3f, 2.3f);
        return randomPos;
    }
}
