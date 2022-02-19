using System;
using UnityEngine;

public class GameManager : GeneralSingleton<GameManager>
{
    #region Variables

    [Header("Lives Settings")]
    [SerializeField] private int _maxLives = 5;
    [SerializeField] private int _startLives = 2;

    [Header("Autoplay")]
    [SerializeField] private bool _isAutoplay;
    [SerializeField] private float _autoplayTimeScale = 2f;

    #endregion


    #region Events

    public event Action OnScoreChanged;
    public event Action OnLivesChanged;

    #endregion


    #region Properties

    public int Score { get; private set; }
    public int CurrentLives { get; private set; }
    public int MaxLives => _maxLives;
    public bool IsAutoplay => _isAutoplay;

    #endregion


    #region Unity lifecycle
    protected override void Awake()
    {
        base.Awake();
        Reload();
    }

    private void OnEnable()
    {
        LevelManager.Instance.OnLevelCleared += LevelCleared;
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnLevelCleared -= LevelCleared;
    }
    private void Update()
    {
        UpdateTimeScale();
    }

    #endregion


    #region Public methods

    public void Reload()
    {
        Score = 0;
        CurrentLives = _startLives;
    }

    public void AddScore(int pointValue)
    {
        Score += pointValue;
        OnScoreChanged?.Invoke();
    }

    public void RemoveLive()
    {
        CurrentLives--;

        if (CurrentLives < 1)
            SceneHelper.Instance.LoadScene(3);

        OnLivesChanged?.Invoke();
    }

    public void AddLive()
    {
        if (CurrentLives >= _maxLives)
            return;

        CurrentLives++;

        OnLivesChanged?.Invoke();
    }

    #endregion


    #region Private methods

    private void UpdateTimeScale()
    {
        if (PauseManager.Instance.IsPaused)
            return;

        Time.timeScale = _isAutoplay ? _autoplayTimeScale : 1;
    }

    private void LevelCleared()
    {
        PauseManager.Instance.Pause();
    }

    #endregion
}