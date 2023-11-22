using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimerUi : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _timer;

    void Update()
    {
        float gameTime = GameManager.instance.GamePlayingTime;

        int minutes = Mathf.FloorToInt(gameTime / 60f);
        int seconds = Mathf.FloorToInt(gameTime - minutes * 60);

        _timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
