using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is written for controlling the time of instantiating the ambulance in the GameOver
//scene. Also, it shows the game over canvas after when the ambulance arrives.

//for "AmbulanceController" in GameOver Scene
public class Amb : MonoBehaviour
{
    public GameObject amb,canv;
    private bool n = false , m = false;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time - t > 6 && n == false)
        {
            Instantiate(amb);
            n = true;
        }
        if (Time.time - t > 10 && m == false)
        {
            Instantiate(canv);
            m = true;
        }
    }
}
