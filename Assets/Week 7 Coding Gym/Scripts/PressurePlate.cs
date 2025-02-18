using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer sr;
    bool activated;
    public GameObject trap;
    public Color activatedCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;
        if (sr.bounds.Contains(playerPos) && !activated)
        {
            trap.GetComponent<TrapScript>().ActivateTrap(Random.ColorHSV());
            activated = true;
            sr.color = activatedCol;
        }
    }
}
