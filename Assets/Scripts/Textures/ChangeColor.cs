using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    SpriteRenderer m_SpriteRenderer;            //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    float m_Red, m_Blue, m_Green;


    // Use this for initialization
    void Start () {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();          //get SpriteRenderer

        m_Green = 1;
        m_Red = 1;
    }

    // Update is called once per frame
    void Update () {
        float x = transform.position.x;

        m_Blue = 1 - (x%60) /60;

        m_NewColor = new Color(m_Red, m_Green, m_Blue);

        //Set the SpriteRenderer to the Color defined by the Sliders
        m_SpriteRenderer.color = m_NewColor;
    }
}
