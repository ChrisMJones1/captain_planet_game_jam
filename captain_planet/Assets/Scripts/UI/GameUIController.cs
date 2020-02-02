﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public Text healthText;
    public Text timeText;
    public Text scoreText;

    private int hp;
    private float time;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Show the time in seconds
        timeText.text = "Time: " + Mathf.Floor(time);
        time += Time.deltaTime;
    }

    //Add the amount to the HP variable and show it in the canvas
    public void UpdateHP(int amount)
    {
        hp += amount;
        healthText.text = "Health: " + hp;
    }

    //Add the amount to the score variable and show it in the canvas
    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}