using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This class contains a function for when the player passes over a mask prefab. In this case,
//it destroys the prefab and set a boolean variable to true.

//for Mask prefab
public class CollectMG : MonoBehaviour
{
    public static bool delMG = false;


    void OnTriggerEnter(Collider Col)
    {
        //If player collected coin, then destroy object
        if (Col.CompareTag("Player"))
        {

            Destroy(gameObject);
            GameData.collectedMGs ++;
            delMG = true;
        }


    }
    //-------------------------
    //Called when object is destroyed
}
