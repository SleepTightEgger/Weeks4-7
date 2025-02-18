using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float health;
    public float speed;
    public float defaultSpeed;
    public float sprintSpeed;
    public float stamina;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = sprintSpeed;
            stamina -= 0.5f;
        } else
        {
            speed = defaultSpeed;
            if (stamina < 100)
            {
                stamina += 0.5f;
            }
        }

        if (health < 0)
        {
            Destroy(gameObject);
        }
        
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
    }
}
