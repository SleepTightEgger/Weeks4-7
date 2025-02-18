using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // register pokemon on this script
    public GameObject player;
    // create visuals for the slider to be updated
    public Slider visuals;

    void Start()
    {
        // set the minimum value of the slider to 0
        visuals.minValue = 0;
        // set the maximum value of the slider to the health variable of the pokemons health stat
        visuals.maxValue = player.GetComponent<MonsterScript>().health;
    }

    void Update()
    {
        // if the registered pokemon is not null then (to stop this from being called and returning errors when a pokemon game object is destroyed)
        if (player != null)
        {
            // update the value of the slider to be equal to the pokemon's health 
            visuals.value = player.GetComponent<MonsterScript>().health;
        }
    }
}
