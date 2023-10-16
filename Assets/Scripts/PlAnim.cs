using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlAnim : MonoBehaviour
{
    private Animator amb;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        amb = GetComponent<Animator>();
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - t > 6)
        {
            amb.enabled = false;
        }
    }
}
