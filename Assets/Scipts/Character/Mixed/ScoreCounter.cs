using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int scoreCounter = 0;

    [SerializeField] TextMeshProUGUI scoreText;
    public int DelayAmount = 1;
    protected float Timer;

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            scoreCounter++; // For every DelayAmount or "second" it will add one to the GoldValue
            scoreText.text = scoreCounter.ToString();
        }
    }
}
