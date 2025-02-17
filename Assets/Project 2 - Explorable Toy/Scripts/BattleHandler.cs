using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject enemyHealth;
    public GameObject playerHealth;
    public GameObject fight;
    public GameObject bag;
    public GameObject monsters;
    public GameObject giveUp;
    bool fightScreen = false;
    public GameObject bite;
    public GameObject bubble;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newPlayer = Instantiate(player);
        newPlayer.transform.position = new Vector2(-6, -1);

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = new Vector2(6, 3);
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
}
