using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    

    public float bulletSpeed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mouse - (Vector2)transform.position;

        transform.up = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 st = spawnPoint.GetComponent<Transform>().transform.position;
            Quaternion sr = spawnPoint.GetComponent<Transform>().transform.rotation;
            Instantiate(bullet, st, sr);

            Bullet newBullet = bullet.GetComponent<Bullet>();
            newBullet.
        }
    }
}
