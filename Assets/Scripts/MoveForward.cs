using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullet moves in a straight line from which it was instantiated
public class MoveForward : MonoBehaviour
{

    Vector3 pos;
    public float maxSpeed = 100f;
    private float monster_rad;

    private float screen_ratio;
    private float width_ortho;

    private void Start()
    {
        screen_ratio = 1.0f * Screen.width / Screen.height;
        width_ortho = screen_ratio * Camera.main.orthographicSize;

        monster_rad = .5f;
    }
    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        //restrict monster to camera bounds
        if (gameObject.layer == 8)
        {
            if (pos.y + monster_rad > Camera.main.orthographicSize)
                pos.y = Camera.main.orthographicSize - monster_rad;
            else if (pos.y - monster_rad < -Camera.main.orthographicSize)
                pos.y = -Camera.main.orthographicSize + monster_rad;

            if (pos.x + monster_rad > width_ortho)
                pos.x = width_ortho - monster_rad;
            else if (pos.x - monster_rad < -width_ortho)
                pos.x = -width_ortho + monster_rad;
        }

        //update position
        transform.position = pos;
    }
}
