using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls the camera position. At the first of the game, it changes the camera
//position from the upper place to the down and then follows the player’s position.

//for camera
public class CameraMotor : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 pos;
    private float transition = 2.0f;
    public static float animationDuration = 2.0f;
    private float yPos;
    private Transform lookAt;
    void Start()
    {
        yPos = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos.x = 0;

        if(transition <= 0)
        {
            transform.position = pos;
        }
        else
        {
            lookAt = GameObject.FindGameObjectWithTag("Player").transform;
            pos.y = yPos + transition;
            transform.position = pos;
            transform.LookAt(lookAt.position + Vector3.up);
            transition -= Time.deltaTime * 1 / animationDuration;

        }
    }
}
