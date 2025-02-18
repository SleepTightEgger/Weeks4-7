using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public GameObject player;
    public Slider visuals;
    public BattleHandler bh;
    // Start is called before the first frame update
    void Start()
    {
        visuals.minValue = 0;
        visuals.maxValue = player.GetComponent<MonsterScript>().health;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            visuals.value = player.GetComponent<MonsterScript>().health;
        }
    }
}
