using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public GameObject spawnPoint;
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mouse - (Vector2)transform.position;

        Transform bsp = spawnPoint.GetComponent<Transform>();

        ;

        Destroy(gameObject, 1);
    }
}
