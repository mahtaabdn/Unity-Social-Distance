using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class controls if the sent mask is hit to a person or not.

//for one child of the player
public class ShootDir : MonoBehaviour
{
    //public static bool isrecieved = false;
    public AudioSource butt;
    public AudioClip Aud;
    private bool peo = false;
    //public static bool animOn = false;

    // Start is called before the first frame update
    private void Update()
    {
        if (PlayerMotor.isSent == true)
        {
            if (peo == true)
            {
                butt.PlayOneShot(Aud);
                //animOn = true;

                GameData.hitedMaskNumber++;
                peo = false;

            }

            PlayerMotor.isSent = false;
        }
    }
    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("People"))
        {
            peo = true;

        }
        else
        {
            peo = false;
        }
       

    }
}
