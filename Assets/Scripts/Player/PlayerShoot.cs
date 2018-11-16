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

    public GameObject bulletPrefab;

    // Use this for initialization
    void Start() {
        firedelay = .35f;
        cooldown = 0f;
        powerup = 0;
        shottyTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            if (fastTimer > 0)
                firedelay = .15f;
            else
                firedelay = .35f;
            fastTimer--;

            cooldown = firedelay;

            Vector3 offset = transform.rotation * new Vector3(0, .5f, 0);
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
