using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public event Action OnStateChanged;

    private StateMaschine _stateMaschine;

    [NonSerialized] public bool GamePaused = false;

    [Header("Time")]
    [SerializeField] public float WaitingToStartTime = 1f;
    [SerializeField] public float CountdownToStartTime = 3f;
    [SerializeField] public float GamePlayingTime = 181f;

    [Header("Ui")]
    [SerializeField] private FadeUi _beforeCountdownUi;
    [SerializeField] private CountdownUi _countdownUi;
    [SerializeField] private GameUi _gameUi;
    [SerializeField] private PauseUi _pauseUi;
    [SerializeField] private GameOverUi _gameOverUi;

    private void Awake()
    {
        instance = this;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _stateMaschine = new StateMaschine();

        var waitingToStart = new WaitingToStartState(this, WaitingToStartTime, _beforeCountdownUi);
        var countdownToStart = new CountdownToStartState(this, CountdownToStartTime, _countdownUi);
        var gamePlaying = new GamePlayingState(this, GamePlayingTime, _gameUi);
        var gamePaused = new GamePausedState(this, _pauseUi);
        var gameOver = new GameOverState(this, _gameOverUi, _gameUi, _pauseUi);

        AddTransition(waitingToStart, countdownToStart, IsWaitingToStartFinished());
        AddTransition(countdownToStart, gamePlaying, IsCountdownToStartFinished());
        AddTransition(gamePlaying, gameOver, IsGamePlayingFinished());

        AddAnyTransition(gamePaused, IsGamePaused());
        AddTransition(gamePaused, gamePlaying, IsGameUnPaused());

        _stateMaschine.SetState(waitingToStart);

        void AddTransition(IState to, IState from, Func<bool> condition) => _stateMaschine.AddTransition(to, from, condition);
        void AddAnyTransition(IState to, Func<bool> condition) => _stateMaschine.AddAnyTransition(to, condition);

        Func<bool> IsWaitingToStartFinished() => () => waitingToStart.NextState;
        Func<bool> IsCountdownToStartFinished() => () => countdownToStart.NextState;
        Func<bool> IsGamePlayingFinished() => () => gamePlaying.NextState;
        Func<bool> IsGamePaused() => () => GamePaused;
        Func<bool> IsGameUnPaused() => () => !GamePaused;
    }

    private void Update() => _stateMaschine.Tick();

    public void InvokeStateChanged()
    {
        OnStateChanged?.Invoke();
    }
}
