using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageHandler : MonoBehaviour {

    public int health = 5;                          //health of player
    public float juggerTimerMax = 0f;               //max time for invulnerability (player into enemy collision)
    public float juggerTimer = 0f;                  //time remaining for invulnerability
    int defaultLayer;                               //default layer for object (in case of modification)

    SpriteRenderer m_SpriteRenderer;            //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    public AudioClip deathsound;
    public AudioClip painsound;
    private AudioSource source;

    // Use this for initialization
    private void Start() {
        defaultLayer = gameObject.layer;                            //assign default layer, in case of later modification
        m_SpriteRenderer = GetComponent<SpriteRenderer>();          //get SpriteRenderer (for transparency during invincibility)
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update() {

        //give invulnerability if time still remaining(before updating position). 
        //If invulnerability is done, return player to normal layer.
        if (juggerTimer > 0) {
            gameObject.layer = 10;
            juggerTimer -= Time.deltaTime;

            //make sprite transparent
            m_NewColor = new Color(1, 1, 1, .5f);
            m_SpriteRenderer.color = m_NewColor;
        } else {
            gameObject.layer = defaultLayer;

            //make sprite opaque
            m_NewColor = new Color(1, 1, 1);
            m_SpriteRenderer.color = m_NewColor;
        }

        //check for health inside Update() to prevent sync issues
        if (health <= 0)
            Die();
    }


    //detect a collision (use rigid body, no triggers)
    private void OnCollisionEnter2D(Collision2D collision) {

        //if player collision with monster
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 15) {
            if (juggerTimer <= 0) {
                health--;

                //grant brief invulnerability IF player is still alive
                if (health > 0) {
                    source.PlayOneShot(painsound, 1.0f);
                    juggerTimer = juggerTimerMax;
                    gameObject.layer = 10;
                }
            }
        }
    }


    //execute upon object death
    private void Die()
    {
        enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PlayerShoot>().enabled = false;
        source.PlayOneShot(deathsound, 1.0f);

        //Updates the highscore and checks it against the list. Inserts highscore into the list.
        HighScore.curHighScore = CurrentScore.Score;
        HighScore.checkHS();


        StartCoroutine(LoadLevelAfterDelay(deathsound.length));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }

    //displayed health on upper left corner
    private void OnGUI()
    {

        GUIStyle HealthGUI = new GUIStyle();

        HealthGUI.fontSize = 25;

        HealthGUI.normal.textColor = Color.black;

        GUI.Label(new Rect(12, 10, 100, 40), "Health: " + health, HealthGUI);
        GUI.Label(new Rect(8, 10, 100, 40), "Health: " + health, HealthGUI);
        GUI.Label(new Rect(10, 8, 100, 40), "Health: " + health, HealthGUI);
        GUI.Label(new Rect(10, 12, 100, 40), "Health: " + health, HealthGUI);

        HealthGUI.normal.textColor = Color.red;

        GUI.Label(new Rect(10, 10, 100, 40), "Health: " + health, HealthGUI);
    }


}
