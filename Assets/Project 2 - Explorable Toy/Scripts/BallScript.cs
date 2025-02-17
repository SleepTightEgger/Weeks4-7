using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public AnimationCurve curve;
    float t;
    public BallSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = new Vector3(curve.Evaluate(t), t);
        Destroy(gameObject, 0.5f);
    }
}
