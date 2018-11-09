using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullet moves in a straight line from which it was instantiated
public class MoveForward : MonoBehaviour
{

    Vector3 pos;
    public float maxSpeed = 8f;

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }
}
