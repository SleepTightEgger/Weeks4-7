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
        visuals.maxValue = 10;
        MonsterScript p = player.GetComponent<MonsterScript>();
        visuals.value = p.health;
        //  MonsterScript p = player.GetComponent<MonsterScript>();
        //  p.healthBar = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        MonsterScript p = player.GetComponent<MonsterScript>();
        p.health -= damage;
        visuals.value = p.health;
    }
}
