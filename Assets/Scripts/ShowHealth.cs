using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class is for managing the heart icons of the canvas. It destroys one of the hearts in case
//a person enters to the safe zone of the player.
public class ShowHealth : MonoBehaviour
{
    public GameObject[] hearts;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(GameData.health == 2)
        {

            Destroy(hearts[0]);
        }
        if (GameData.health == 1)
        {

            Destroy(hearts[1]);
        }
        if (GameData.health == 0)
        {

            Destroy(hearts[2]);
        }

        
    }

}
