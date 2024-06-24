using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    private float score;
    private bool count = true;
    void Update()
    {
        if (!count)
        {
            return;
            }
        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }
    public int stopScoring()
    {
        count = false;
        scoreText.text = string.Empty;
        return Mathf.FloorToInt(score);
    }

    internal void startTimer()
    {
        count = true;
    }
}
