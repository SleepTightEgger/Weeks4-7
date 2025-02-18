using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public AnimationCurve curve;
    public AnimationCurve curve2;
    public float t;
    public float health;
    public string monsterName;
    public float attack;
    public float defense;
    public float spatk;
    public float spdef;
    public float speed;

    public List<MovesScript> knownMoves;
    bool isDead = false;
    //public Healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (t < 1 && !isDead)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * curve.Evaluate(t * 5);
        }

        if (health <= 0 && !isDead)
        {
            t = 0;
            isDead = true;
        }

        if (t < 1 && isDead)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * curve2.Evaluate(t * 5);
            Destroy(gameObject, 1);
        }
    }
}
