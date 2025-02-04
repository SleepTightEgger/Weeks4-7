using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour
{
    public GameObject player;
    bool close;
    // Start is called before the first frame update
    void Start()
    {
        close = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ppos = player.transform.position;
        if (ppos.x > transform.position.x - 1 &&
            ppos.x < transform.position.x + 1 &&
            ppos.y > transform.position.y - 1 &&
            ppos.y < transform.position.y +1)
        {
            close = true;
        } else
        {
            close = false;
        }
    }
}
