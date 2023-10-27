using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public GameObject flyingSpawner;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        score += 1;
        scoreText.text = score.ToString();
        if (score == 8)
        {
            flyingSpawner.SetActive(true);
        }
    }

    public void Hurt()
    {
        score -= 1;
        scoreText.text = score.ToString();
    }
}
