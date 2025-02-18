using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 10;
    public GameObject player;
    public float damage;
    void Start()
    {
        transform.up = new Vector3(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x -= speed * Time.deltaTime;

        transform.position = pos;

        if (player.GetComponent<SpriteRenderer>().bounds.Contains(pos)) 
        {
            player.GetComponent<PlayerMovement>().health -= damage;
            Destroy(gameObject, 1);
        }
        
    }
}
