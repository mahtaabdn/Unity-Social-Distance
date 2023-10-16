using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class is written to define the speed of people. As the level of difficulty of the game
//increases, the new people’s speed increase too.

//for people prefabs
public class PeopleWalk : MonoBehaviour
{
    //private Transform target;
    public float PeopleSpeed;
    private Vector3 moveVec;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        PeopleSpeed += 0.25f * GameData.difficultyLevel;
        //target.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //float step = PeopleSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        moveVec = Vector3.zero;

        //left & right (X)
        moveVec.x = 0;
        //up & down (Y)
        moveVec.y = 0;
        //forward & backward (Z)
        moveVec.z = PeopleSpeed;


        controller.Move(-moveVec* Time.deltaTime);
    }
}
