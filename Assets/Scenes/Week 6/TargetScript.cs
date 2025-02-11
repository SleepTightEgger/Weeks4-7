using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float speed = 1;
    public Color col;
    public AnimationCurve curve;
    float t;
    bool isDead = false;
    public TargetSpawner spawner;

    public SpriteRenderer sr;

    private void Start()
    {
        speed = Random.Range(1, 5);
    }

    private void Update()
    {
        Vector2 pos = transform.position;
        Vector2 ScreenPos = Camera.main.WorldToScreenPoint(pos);

        pos.x += speed * Time.deltaTime;

        if (ScreenPos.x < 0)
        {
            speed *= -1;
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        }

        if (ScreenPos.x > Screen.width)
        {
            speed *= -1;
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        }

        transform.position = pos;

        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (sr.bounds.Contains(mousePos))
            {
                sr.color = col;
                isDead = true;
                Destroy(gameObject, 1);
                spawner.TargetHit(gameObject);
            }
        }

        if (isDead)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * curve.Evaluate(t);
        }

    }
}
