using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScoreUi : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        _scoreText.text = "Score: " + ScoreManager.instance.Score.ToString();
    }
}
