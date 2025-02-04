using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI score;
    int scoreValue = 0;
    bool isPlaying = true;
    // Start is called before the first frame update
    void Start()
    {
        score.text = scoreValue.ToString();
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying && Input.GetMouseButtonDown(0))
        {
            scoreValue++;
            score.text = scoreValue.ToString();
        }

        if (scoreValue > 10)
        {
            gameOverScreen.SetActive(true);
            isPlaying = false;
        }

        if (!isPlaying && Input.GetKeyDown(KeyCode.Space))
        {
            scoreValue = 0;
            score.text = scoreValue.ToString();
            gameOverScreen.SetActive(false);
            isPlaying=true;
        }
    }
}
