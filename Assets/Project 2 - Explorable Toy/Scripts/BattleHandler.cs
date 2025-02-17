using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
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
       // GameObject newPlayer = Instantiate(enemy);
       // newPlayer.transform.position = Vector2.one;

      //  GameObject newEnemy = Instantiate(player);
      //  newEnemy.transform.position = Vector2.one;
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
