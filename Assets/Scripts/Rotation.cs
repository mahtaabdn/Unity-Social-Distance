using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationRate = 50f;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up, rotationRate * Time.deltaTime);
    }
}
