using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Vector3 mouse_pos;
    private Vector3 pos;
    public float move_speed = .1f;
    private float player_rad;

    private float screen_ratio;
    private float width_ortho;

	// Use this for initialization
	void Start () {
        screen_ratio = 1.0f * Screen.width / Screen.height;
        width_ortho = screen_ratio * Camera.main.orthographicSize;

        player_rad = .5f;
	}

    // Update is called once per frame
    void Update () {

        //if right mouser button is clicked, move
        if (Input.GetMouseButton(1))
        {
            //current player position
            pos = transform.position;

            //get current mouse position
            mouse_pos = Input.mousePosition;
            mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

            //move in direction of mouse when right button held down (lerp for smoothness)
            pos = Vector2.Lerp(pos, mouse_pos, move_speed);

            //point player toward mouse
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mouse_pos - pos);

            //restrict player to camera bounds
            if (pos.y + player_rad > Camera.main.orthographicSize)
                pos.y = Camera.main.orthographicSize - player_rad;
            else if (pos.y - player_rad < -Camera.main.orthographicSize)
                pos.y = -Camera.main.orthographicSize + player_rad;
            
            if (pos.x + player_rad > width_ortho)
                pos.x = width_ortho - player_rad;
            else if (pos.x - player_rad < -width_ortho)
                pos.x = -width_ortho + player_rad;

            //update player pos
            transform.position = pos;
        }
    }
}
