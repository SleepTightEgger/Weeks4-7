using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    //set up animation curves for when the pokemon comes out or dies
    public AnimationCurve curve;
    public AnimationCurve curve2;
    //set up time float for animation curve
    public float t;
    //set up stats for pokemon
    public float health;
    public string monsterName;
    public float attack;
    public float defense;
    public float spatk;
    public float spdef;

    //create a list of moves that the pokemon knows
    public List<MovesScript> knownMoves;
    //boolean variable for when the pokemon is dead
    bool isDead = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if time is less than 1 and pokemon is not dead then
        if (t < 1 && !isDead)
        {
            // increment the time variable by time.deltaTime each frame
            t += Time.deltaTime;
            // scale the pokemon up by evaluating the curve at the time variable(to simulate pokemon exiting pokeball)
            transform.localScale = Vector3.one * curve.Evaluate(t * 5);
        }

        // if the health is less than or equal to 0 and pokemon has not yet been flagged as dead then.,
        if (health <= 0 && !isDead)
        {
            // reset time float to 0 for death animation curve
            t = 0;
            // flag the pokemon as dead
            isDead = true;
        }

        // if time is less than 1 and the pokemon is flagged as dead then,
        if (t < 1 && isDead)
        {
            // increment the time variable by time.deltaTime each frame
            t += Time.deltaTime;
            // scale the pokemon down by evaluating the curve at time variable (to simulate pokemon returning to pokeball)
            transform.localScale = Vector3.one * curve2.Evaluate(t * 5);
            // destroy the this game object
            Destroy(gameObject, 1);
        }
    }
}
