using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class BattleHandler : MonoBehaviour
{
    // register player and enemy pokemon prefabs
    public GameObject enemy;
    public GameObject player;
    // register healthbars for both player and enemies
    public Healthbar enemyHealth;
    public Healthbar playerHealth;
    // register buttons and text slider
    public GameObject fight;
    public GameObject potion;
    public GameObject textSlider;
    public GameObject move1;
    public GameObject move2;
    public GameObject move3;
    public GameObject move4;
    // register text for text objects
    public TextMeshProUGUI description;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI enemyName;

    public TextMeshProUGUI move1Name;
    public TextMeshProUGUI move2Name;
    public TextMeshProUGUI move3Name;
    public TextMeshProUGUI move4Name;

    // register float and boolean for determining selected move strength
    float selectedMovePower;
    bool selectedMoveStab;

    // create an array of instantiated monsters
    public List<GameObject> spawnedMonsters;
 
    void Start()
    {
        // register list of spawned pokemon game objects
        spawnedMonsters = new List<GameObject>();

        // instantiate the player pokemon prefab 
        GameObject newPlayer = Instantiate(player);
        //set its position to player pokemon location
        newPlayer.transform.position = new Vector2(-6, -1);
        // add it to the list of spawned monsters
        spawnedMonsters.Add(newPlayer);

        // instantiate the enemy pokemon prefab
        GameObject newEnemy = Instantiate(enemy);
        // set its position to enemy pokemon location
        newEnemy.transform.position = new Vector2(6, 3);
        // add it to the list of spawned monsters
        spawnedMonsters.Add(newEnemy);

        //set the instantiated player and enemy pokemon as the "owners" or "subject" of health bars
        playerHealth.player = newPlayer;
        enemyHealth.player = newEnemy;

        // set the text on the nameplate to the names of the instantiated pokemon [0] for player, [1] for enemy
        playerName.text = spawnedMonsters[0].GetComponent<MonsterScript>().monsterName;
        enemyName.text = spawnedMonsters[1].GetComponent<MonsterScript>().monsterName;

        // set the text of the move buttons to the names of the known moves of the player pokemon
        move1Name.text = spawnedMonsters[0].GetComponent<MonsterScript>().knownMoves[0].moveName;
        move2Name.text = spawnedMonsters[0].GetComponent<MonsterScript>().knownMoves[1].moveName;
        move3Name.text = spawnedMonsters[0].GetComponent<MonsterScript>().knownMoves[2].moveName;
        move4Name.text = spawnedMonsters[0].GetComponent<MonsterScript>().knownMoves[3].moveName;
    }
        void Update()
    {

    }
    // action select function, all of this is true by default but this function is called to reset it back after the player chooses their move
    public void ActionSelect()
    {
        // set the text on the description box for when you need to choose an action
        description.text = "What will you do?";
        // set fight button, potion button, and text slider to game objects to active
        fight.SetActive(true);
        potion.SetActive(true);
        textSlider.SetActive(true);

        // set move buttons to unactive
        move1.SetActive(false);
        move2.SetActive(false);
        move3.SetActive(false);
        move4.SetActive(false);
    }

    public void MoveSelect()
    {
        // set the text on the description box to prompt players to select their move
        description.text = "Select a move.";
        // set move buttons to active
        move1.SetActive(true);
        move2.SetActive(true);
        move3.SetActive(true);
        move4.SetActive(true);
        // set fight button, potion button, and text slider to game objects to unactive
        fight.SetActive(false);
        potion.SetActive(false);
        textSlider.SetActive(false);
    }

    // movePower function to set the selected moves power (done like this to work around buttons only being able to call a function that passes in a single variable)
    public void movePower(float power)
    {
        // store the power of the move that had its button pressed as a local variable
        selectedMovePower = power;
    }

    // moveStab function to determine if the move has a Same Type Attack Bonus (done like this to work around buttons only being able to call a function that passes in a single variable)
    public void moveStab(bool stab)
    {
        // store the stab boolean of the move that had its button pressed as a local variable
        selectedMoveStab = stab;
    }
    // move category function to determine if the attack is physical or special attack (done like this to work around buttons only being able to call a function that passes in a single variable)
    public void moveCategory(bool physical)
    {
        // call damage enemy function using stored power and stab boolean as well as physical boolean
        DamageEnemy(selectedMovePower, selectedMoveStab, physical);
        // call the enemy move function so that the enemy may attack you after you've chosen your attack
        EnemyMove();
    }

    // enemy move function
    void EnemyMove()
    {
        // grab a random move from the list of known moves given to the enemy pokemon
        MovesScript enemyMove = spawnedMonsters[1].GetComponent<MonsterScript>().knownMoves[Random.Range(0,3)];
        // if the move is Roost then,
        if (enemyMove.moveName == "Roost")
        {
            // call the heal enemy function
            healEnemy();
        } 
        // else
        else
        // if the move's type is fire then,
        if (enemyMove.type == "Fire")
        {
            // call the damage player function inputting move power, type effectiveness set to false, and physical move set to false
            DamagePlayer(enemyMove.power, false, false);
        }
        // if the move's type is electric then,
        if (enemyMove.type == "Electric")
        {
            // call the damage player function inputting move power, type effectiveness set to true, and physical move set to true
            DamagePlayer(enemyMove.power, true, true);
        }
        // if the move's type is steel then,
        if (enemyMove.type == "Steel")
        {
            // call the damage player function inputting move power, type effectiveness set to false, and physical move set to true
            DamagePlayer(enemyMove.power, false, true);
        }
    }

    // damage enemy function, taking in power, same type attack bonus boolean, and physical/special boolean
    public void DamageEnemy(float power, bool stab, bool physical)
    {
        // get the attack stat of the player pokemon and store it as a local variable
        float pa = spawnedMonsters[0].GetComponent<MonsterScript>().attack;
        // get the defense stat of the enemy pokemon and store it as a local variable
        float ed = spawnedMonsters[1].GetComponent<MonsterScript>().defense;
        // get the special attack stat of the player pokemon and store it as a local variable
        float psa = spawnedMonsters[0].GetComponent<MonsterScript>().spatk;
        // get the special defense stat of the enemy pokemon and store it as a local variable
        float esd = spawnedMonsters[1].GetComponent<MonsterScript>().spdef;

        // if it is a physical damage move then,
        if (physical) { 
            // if it physical and has the same type attack bonus boolean then, (the move is waterfall)
            if (stab)
            {
                // using pokemons Generation 2 damage calculation, subtract enemies health by -> (level * 2 /5) + 2 * moves power * (attack / defense) all divided by 50 then multiply that number by 1.5 for same type attack bonus
                spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (pa / ed) / 50) * 1.5f;
            }
            // if it is physical and does not have the same type attack bonus boolean then, (the move is metal claw)
            if (!stab)
            {
                // using pokemons Generation 2 damage calculation, same as above but this time all * 1 because no STAB and then * 0.5 because not effective move type
                spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (pa / ed) / 50) * 1 * 0.5f;
            }
        }
        // if the move is not a physical damage move then, (the move is hydro pump)
        if (!physical)
        {
            // using pokemons Generation 2 damage calculation, same as above (removed type *2 damage for super effective because it was too much damage, only stab applies)
            spawnedMonsters[1].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (psa / esd) / 50) * 1.5f;
        }

        // update the enemies healthbar to reflect new health amount
        enemyHealth.visuals.value = spawnedMonsters[1].GetComponent<MonsterScript>().health;
    }

    // heal enemy function, called when enemy rolls roost for random move
    void healEnemy()
    {
        // increase enemies health by half of enemy max health
        spawnedMonsters[1].GetComponent<MonsterScript>().health += 39;
    }

    // damage player function, same as above but slightly modified to account for charizards moves and type effectiveness against empoleon
    public void DamagePlayer(float power, bool effective, bool physical)
    {
        // get the attack stat of the enemy pokemon and store it as a local variable
        float ea = spawnedMonsters[1].GetComponent<MonsterScript>().attack;
        // get the defense stat of the player pokemon and store it as a local variable
        float pd = spawnedMonsters[0].GetComponent<MonsterScript>().defense;
        // get the special attack stat of the enemy pokemon and store it as a local variable
        float esa = spawnedMonsters[1].GetComponent<MonsterScript>().spatk;
        // get the special defense stat of the player pokemon and store it as a local variable
        float psd = spawnedMonsters[0].GetComponent<MonsterScript>().spdef;
        
        //if the move is a physical damage move then,
        if (physical)
        {
            // if the type is effective then, (the move is thunder punch)
            if (effective)
            {
                // using pokemons Generation 2 damage calculation, same as above (removed super effectiveness because of one shot)
                spawnedMonsters[0].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (ea / pd) / 50) * 1;
            }
            // if the type is not effective then, (the move is metal claw)
            if (!effective)
            {
                // using pokemons Generation 2 damage calculation, same as above but this time *0.25 because Empoleon is double resistant to steel type moves
                spawnedMonsters[0].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (ea / pd) / 50) * 1 * 0.25f;
            }
        }
        // if the move is not a physical damage move then, (the move is overheat)
        if (!physical)
        {
            // using pokemons Generation 2 damage calculation, same as above (removed super effectiveness because of one shot, only STAB applies)
            spawnedMonsters[0].GetComponent<MonsterScript>().health -= (((2 * 50 / 5) + 2) * power * (esa / psd) / 50) * 1.5f;
        }

        // update the players healthbar to reflect new health amount
        playerHealth.visuals.value = spawnedMonsters[0].GetComponent<MonsterScript>().health;
    }

    // heal player function, called when player picks roost or potion action
    public void healPlayer(float heal)
    {
        // increase player pokemon health by either half of pokemon health or by potion amount
        spawnedMonsters[0].GetComponent<MonsterScript>().health += heal;
        // call enemy move function as you used your turn to use a potion
        EnemyMove();
    }

    //text size slider function
    public void TextSize(float size)
    {
        // set the font size for the game text based on the value of the text size slider.
        description.fontSize = size;
        playerName.fontSize = size;
        enemyName.fontSize = size;
    }
}
