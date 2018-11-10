using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//LATER: use NavMeshAgent

//object moves in a straight line from which it is facing
//because bullet never changes direction, thsi will always be used
public class MoveForward : MonoBehaviour
{
    public float speed = .05f;

    private float screen_ratio;
    private float width_ortho;

    private void Start()
    {
        //get screen width and height (NOT currently used)
        screen_ratio = 1.0f * Screen.width / Screen.height;
        width_ortho = screen_ratio * Camera.main.orthographicSize;
    }

    //use transform.Translate to use the rigidbody (NOT transform.position)
    private void Update()
    {
        transform.Translate(0, speed, 0);
    }
}
