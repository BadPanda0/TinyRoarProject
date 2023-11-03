using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    void Start() => ScoreManager.instance.ScoreChanged += SetScoreText;

    public void SetScoreText()
    {
        _score.text = ScoreManager.instance.Score.ToString();
    }
}
