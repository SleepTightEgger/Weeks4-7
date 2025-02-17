using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject newBall = Instantiate(ball);
        newBall.transform.position = Vector3.zero;

        BallScript b = newBall.GetComponent<BallScript>();
        b.spawner = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
