using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShoot: MonoBehaviour
{
    private float firedelay;
    private float cooldown;
    private int powerup;
    private int shottyTimer;
    public int fastTimer;

    public AudioClip shoot;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    public GameObject bulletPrefab;
    public GameObject soundPrefab;

    // Use this for initialization
    void Start() {
        firedelay = .3f;
        cooldown = 0f;
        powerup = 0;
        shottyTimer = 0;
<<<<<<< HEAD
        soundPrefab = GameObject.FindWithTag("Sound");
=======
        source = GetComponent<AudioSource>();
>>>>>>> master
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            soundPrefab.GetComponent<SoundHandler>().playSound(0);
            if (fastTimer > 0)
                firedelay = .15f;
            else
                firedelay = .3f;
            fastTimer--;

            cooldown = firedelay;

            Vector3 offset = transform.rotation * new Vector3(0, .5f, 0);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(shoot, vol);
            GameObject b = Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

            //if regular shooting
            b.layer = LayerMask.NameToLayer("Bullet");

            //if shotgun powerup active, use it
            if (powerup != 0)
            {
                if(powerup == 1)
                    shottyTimer = 20;
                powerup = 0;
            }

            //if time is still remaining on the powerup
            if(shottyTimer > 0) {
                GameObject c = Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                GameObject d = Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

                c.transform.Rotate(0, 0, 45);
                d.transform.Rotate(0, 0, -45);

                c.layer = LayerMask.NameToLayer("Bullet");
                d.layer = LayerMask.NameToLayer("Bullet");

                shottyTimer--;
            }
        }
    }

    public void receivePowerup(int p)
    {
        powerup = p;
    }
}
