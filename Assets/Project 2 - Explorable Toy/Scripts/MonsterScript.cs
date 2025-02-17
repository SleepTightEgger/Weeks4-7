using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public AnimationCurve curve;
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * curve.Evaluate(t);
    }
}
