using System;
using UnityEngine;

public class GameManager : GeneralSingleton<GameManager>
{
    #region Variables
        
    public int Lives = 3;
    private bool _isGameOver;

    #endregion


    #region Events

    public event Action OnScoreUpdated;

    #endregion


    #region Properties

    public int Score { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        Reset();
    }

    private void OnEnable()
    {
        LevelManager.Instance.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnGameOver -= GameOver;
    }

    #endregion


    #region Public methods

    public void Reset()
    {
        Score = 0;
        Lives = 3;
        _isGameOver = false;
    }

    public void AddScore(int pointValue)
    {
        Score += pointValue;
        OnScoreUpdated?.Invoke();
    }

    #endregion


    #region Private methods

    private void GameOver()
    {
        if (_isGameOver)
            return;
        _isGameOver = true;
    }

    #endregion
}