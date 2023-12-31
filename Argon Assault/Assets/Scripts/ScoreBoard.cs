using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    TMP_Text scoreText;

    private void Start() {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int scoreIncrease)
    {
        score += scoreIncrease;
        scoreText.text = score.ToString();
    }
}
