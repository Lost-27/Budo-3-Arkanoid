using UnityEngine;

public class GameManager : GeneralSingleton<GameManager>
{
    #region Variables

    public int lives = 3;
    private bool _isGameOver;

    #endregion


    #region Properties

    public int Score { get; private set; }    
    
    #endregion


    #region Unity lifecycle    
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
        _isGameOver = false;
    }
    public void AddScore(int pointValue)
    {
        Score += pointValue;        
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
