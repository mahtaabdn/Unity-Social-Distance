using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is associated with "ambulance" prefab. It controls the ambulance’s animation.
public class AmbAnim : MonoBehaviour
{
    private Animator amb;
    public static bool menuTime = false;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        amb = GetComponent<Animator>();
        t = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time - t > 6)
        {
            amb.enabled = false;
        }

    }
}
