using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class contains a function for when the player passes over an angel prefab. In this case,
//it destroys the prefab and set a boolean variable to true.

//for Angel prefab
public class CollectAngel : MonoBehaviour
{
    public static bool angelTime = false;
    void OnTriggerEnter(Collider Col)
    {
        //If player collected coin, then destroy object
        if (Col.CompareTag("Player"))
        {

            Destroy(gameObject);
            angelTime = true;
            PlayerMotor.becomeAngel = true;
        }


    }
}
