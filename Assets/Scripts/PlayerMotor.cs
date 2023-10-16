using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for Player prefab
public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 3.5f, firstY;
    private Vector3 moveVector;
    public static float verticalVeloity = 0.0f;
    public static float meters = 0;
    private float t, sendx, sendy, startTime;
    public AudioSource butt, shootA;
    public AudioClip Aud, Aud1;
    public GameObject sendButton , wingR, wingL, blueLine, blueCircle, walkSound, greenCircle, sendBut;
    public static bool isSent = false , flyEnd = false, becomeAngel = false ,downingTime = false, destAngMask = false;
    public Animator an;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        wingL.SetActive(false);
        wingR.SetActive(false);
        t = Time.time;
        controller = GetComponent<CharacterController>();
        sendx = sendButton.transform.position.x;
        sendy = sendButton.transform.position.y;
        firstY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - t < CameraMotor.animationDuration * 2)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;
        
        //left & right (X)
        moveVector.x = Input.GetAxisRaw("Horizontal") * (speed + 0.2f * GameData.difficultyLevel) * 0.7f;
        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x > sendx+45 || Input.mousePosition.x < sendx-45 || Input.mousePosition.y > sendy+45 || Input.mousePosition.y < sendy - 45)
            {
                if (Input.mousePosition.x > Screen.width / 2)
                {
                    moveVector.x = (speed + 0.2f * GameData.difficultyLevel) * 0.7f;
                }
                else
                {
                    moveVector.x = -1 * ((speed + 0.2f * GameData.difficultyLevel) * 0.7f);
                }
            }


        }

        
        //up & down (Y)
        moveVector.y = verticalVeloity;
        //forward & backward (Z)
        moveVector.z = speed + 0.15f * GameData.difficultyLevel;


        controller.Move(moveVector * Time.deltaTime);
        meters = transform.position.z/3 - 2;



        if (SpawnAngel.fly == true)
        {
            wingR.SetActive(true);
            wingL.SetActive(true);
            walkSound.SetActive(false);
            blueLine.SetActive(false);
            blueCircle.SetActive(false);
            greenCircle.SetActive(false);
            sendBut.SetActive(false);
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            if (playerTransform.position.y > 4.5f)
            {
                SpawnAngel.fly = false;
                verticalVeloity = 0;
                startTime = Time.time;
                downingTime = true;
                becomeAngel = false;
                //AngelTime.spawnOnce = false;
            }

        }
        if(Time.time - startTime > 15 && downingTime == true && becomeAngel == false)
        {
            if(GameObject.FindGameObjectWithTag("Player").transform.position.y > firstY+0.1f)
            {
                if (playerTransform.position.y > 1)
                {
                    verticalVeloity = -1;
                }
                if (GameObject.FindGameObjectWithTag("Player").transform.position.y <= 1)
                {
                    verticalVeloity = -GameObject.FindGameObjectWithTag("Player").transform.position.y+ firstY;
                }
                //destAngMask = true;
            }

            else
            {
                verticalVeloity = 0;
                flyEnd = true;

                wingR.SetActive(false);
                wingL.SetActive(false);
                walkSound.SetActive(true);
                blueLine.SetActive(true);
                blueCircle.SetActive(true);
                greenCircle.SetActive(true);
                sendBut.SetActive(true);
                downingTime = false;
            }
        }
    }

    //when a person come to safe zone
    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("People") && becomeAngel == false && downingTime == false)
        {
            butt.PlayOneShot(Aud);
            GameData.health --;
        }


    }

    //for pressing send icon
    public void SendMask()
    {
        butt.PlayOneShot(Aud1);
        if (GameData.collectedMGs > 0)
        {
            an.SetTrigger("isPre");
            GameData.collectedMGs--;
            //an.SetBool("SendIsPressed", false);
            //clickTime = Time.time;
            isSent = true;

        }

    }
}
