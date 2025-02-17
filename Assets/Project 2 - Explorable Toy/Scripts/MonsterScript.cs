using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public AnimationCurve curve;
    public AnimationCurve curve2;
    public float t;
    public float health = 10;
    bool isDead = false;
    //public Healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * curve.Evaluate(t*5);

        if (health <= 0)
        {
            isDead = true;
        }

        if (isDead)
        {
            transform.localScale = Vector3.one * curve2.Evaluate(t * 5);
            Destroy(gameObject);
        }
    }
}
