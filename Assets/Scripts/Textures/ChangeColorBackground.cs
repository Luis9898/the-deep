using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorBackground : MonoBehaviour {

    SpriteRenderer m_SpriteRenderer;            //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    // Use this for initialization
    void Start () {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();          //get SpriteRenderer
    }

    // Update is called once per frame
    void Update () {
        float y = transform.position.y / 200 + 1;

        m_NewColor = new Color(y, y, y);

        //Set the SpriteRenderer to the Color defined by the Sliders
        m_SpriteRenderer.color = m_NewColor;
    }
}
