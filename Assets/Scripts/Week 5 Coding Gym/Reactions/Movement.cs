using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 20;
    public GameObject tri;
    bool close;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);

        Vector3 tpos = tri.transform.position;
        if (tpos.x > transform.position.x - 1 &&
            tpos.x < transform.position.x + 1 &&
            tpos.y > transform.position.y - 1 &&
            tpos.y < transform.position.y + 1)
        {
            close = true;
        }
        else
        {
            close = false;
        }

        if (close)
        {
            
        }
    }
}
