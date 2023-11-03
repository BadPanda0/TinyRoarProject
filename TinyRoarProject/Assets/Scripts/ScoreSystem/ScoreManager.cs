using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public event Action ScoreChanged;

    public int Score = 0;

    private void Awake()
    {
        instance = this;
    }

    public void ManipulateScore(int Amount)
    {
        Score += Amount;
        ScoreChanged();
    }
}
