using System.Collections.Generic;

public class BallsContainer : GeneralSingleton<BallsContainer>
{
    #region Variables

    private List<Ball> _balls = new List<Ball>();

    #endregion


    #region Properties

    public List<Ball> Balls => _balls;

    #endregion


    #region Unity lifecycle

    private void OnEnable()
    {
        Ball.OnCreated += BallCreated;
        Ball.OnDestroyed += BallDestroyed;
    }


    private void OnDestroy()
    {
        Ball.OnCreated -= BallCreated;
        Ball.OnDestroyed -= BallDestroyed;
    }

    #endregion


    #region Private methods

    private void BallCreated(Ball ball)
    {
        _balls.Add(ball);
    }

    private void BallDestroyed(Ball ball)
    {
        _balls.Remove(ball);
    }

    #endregion
}