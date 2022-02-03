using System;
using TMPro;
using UnityEngine;

public class GameManager : GeneralSingleton<GameManager>
{
    #region Variables

    public int lives = 3;

    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private TextMeshProUGUI _scoreLabel;
        
    #endregion


    #region Properties
        
    public int Score { get; private set; }
    public bool IsPaused { get; private set; }

    #endregion


    #region Unity lifecycle
     

    private void Start()
    {
        UpdateScoreOnScreen();
    }

    private void Update()
    {
        if (IsEscPressed())
        {
            ChangePaused();
        }
    }


    private void ChangePaused()
    {
        IsPaused = !IsPaused;

        Time.timeScale = IsPaused ? 0 : 1;
    }

    #endregion


    #region Public methods

    public void AddScore(int pointValue)
    {
        Score += pointValue;
        UpdateScoreOnScreen();
    }

    #endregion


    #region Private methods

    private void UpdateScoreOnScreen()
    {
        _scoreLabel.text = "Score: " + Score;
    }

    private bool IsEscPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    #endregion

}
