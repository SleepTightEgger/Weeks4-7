using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Healthbar enemyHealth;
    public Healthbar playerHealth;
    public GameObject fight;
    public GameObject potion;
    public GameObject monsters;
    public GameObject giveUp;
    public bool fightScreen = false;
    public GameObject move1;
    public GameObject move2;
    public GameObject move3;
    public GameObject move4;
    public TextMeshProUGUI description;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI enemyName;

    public TextMeshProUGUI move1Name;
    public TextMeshProUGUI move2Name;
    public TextMeshProUGUI move3Name;
    public TextMeshProUGUI move4Name;

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
        //test.health = 10;
        playerHealth.player = newPlayer;

        MonsterScript test2 = newEnemy.GetComponent<MonsterScript>();
        //test2.health = 10;
        enemyHealth.player = newEnemy;

        playerName.text = spawnedMonsters[0].GetComponent<MonsterScript>().name;
        enemyName.text = spawnedMonsters[1].GetComponent<MonsterScript>().name;

        move1Name.text = spawnedMonsters[0].GetComponent<MonsterScript>().knownMoves[0].name;
        move2Name.text = spawnedMonsters[0].GetComponent<MonsterScript>().knownMoves[1].name;
        move3Name.text = spawnedMonsters[0].GetComponent<MonsterScript>().knownMoves[2].name;
        move4Name.text = spawnedMonsters[0].GetComponent<MonsterScript>().knownMoves[3].name;
    }
        // Update is called once per frame
        void Update()
    {

    }
    public void ActionSelect()
    {
        description.text = "What will you do?";
        fight.SetActive(true);
        potion.SetActive(true);
        monsters.SetActive(true);
        giveUp.SetActive(true);

        move1.SetActive(false);
        move2.SetActive(false);
        move3.SetActive(false);
        move4.SetActive(false);
    }

    public void MoveSelect()
    {
        description.text = "Select a move.";
        move1.SetActive(true);
        move2.SetActive(true);
        move3.SetActive(true);
        move4.SetActive(true);

        fight.SetActive(false);
        potion.SetActive(false);
        monsters.SetActive(false);
        giveUp.SetActive(false);
    }

    public void DamageEnemy(float power, bool stab, bool physical)
    {
        float pa = spawnedMonsters[0].GetComponent<MonsterScript>().attack;
        float ed = spawnedMonsters[1].GetComponent<MonsterScript>().defense;
        float psa = spawnedMonsters[0].GetComponent<MonsterScript>().spatk;
        float esd = spawnedMonsters[1].GetComponent<MonsterScript>().spdef;

        if (physical) { 
            if (stab)
            {
                spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (pa / ed) / 50) * 1.5f * 2;
            }
            if (!stab)
            {
                spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (pa / ed) / 50) * 1 * 0.5f;
            }
        }
        if (!physical)
        {
            if (stab)
            {
                spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (psa / esd) / 50) * 1.5f * 2;
            }
            if (!stab)
            {
                spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (psa / esd) / 50) * 1 * 0.5f;
            }
        }

        enemyHealth.visuals.value = spawnedMonsters[1].GetComponent<MonsterScript>().health;
    }

    public void DamagePlayer(float power, bool effective, bool physical)
    {
        float ea = spawnedMonsters[1].GetComponent<MonsterScript>().attack;
        float pd = spawnedMonsters[0].GetComponent<MonsterScript>().defense;
        float esa = spawnedMonsters[1].GetComponent<MonsterScript>().spatk;
        float psd = spawnedMonsters[0].GetComponent<MonsterScript>().spdef;

        if (physical)
        {
            if (effective)
            {
                spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (ea / pd) / 50) * 1 * 2;
            }
            if (!effective)
            {
                spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (ea / pd) / 50) * 1 * 0.25f;
            }
        }
        if (!physical)
        {
            spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (esa / psd) / 50) * 1.5f * 1;
        }

        playerHealth.visuals.value = spawnedMonsters[0].GetComponent<MonsterScript>().health;
    }
}
