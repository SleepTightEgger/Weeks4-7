using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer sr;
    public GameObject Arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateTrap(Color col)
    {
        sr.color = col;
        Instantiate(Arrow, transform.position, Quaternion.identity);
        Arrow.GetComponent<ArrowMovement>().player = player;
        
    }
}
