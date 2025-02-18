using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Healthbar enemyHealth;
    public Healthbar playerHealth;
    public GameObject fight;
    public GameObject bag;
    public GameObject monsters;
    public GameObject giveUp;
    bool fightScreen = false;
    public GameObject bite;
    public GameObject bubble;

    public List<GameObject> spawnedMonsters = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        spawnedMonsters = new List<GameObject>();

        GameObject newPlayer = Instantiate(player);
        newPlayer.transform.position = new Vector2(-6, -1);
        spawnedMonsters.Add(newPlayer);
        
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = new Vector2(6, 3);
        spawnedMonsters.Add(newEnemy);

        MonsterScript test = newPlayer.GetComponent<MonsterScript>();
        test.health = 10;
        playerHealth.player = newPlayer;

        MonsterScript test2 = newEnemy.GetComponent<MonsterScript>();
        test2.health = 10;
        enemyHealth.player = newEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (fightScreen)
        {
            bite.SetActive(true);
            bubble.SetActive(true);
        }
    }

    public void Damage(float damage)
    {
        spawnedMonsters[1].GetComponent<MonsterScript>().health -= damage;
        playerHealth.visuals.value = spawnedMonsters[0].GetComponent<MonsterScript>().health;
        enemyHealth.visuals.value = spawnedMonsters[1].GetComponent<MonsterScript>().health;
    }
}
