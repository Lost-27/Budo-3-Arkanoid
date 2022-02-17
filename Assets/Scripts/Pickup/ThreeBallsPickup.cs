using System.Collections.Generic;
using UnityEngine;

public class ThreeBallsPickup : PickupBase
{
    #region Variables

    [SerializeField] private int _ballCount;

    #endregion

    #region Private methods

    protected override void ApplyPickup()
    {
        List<Ball> balls = BallsContainer.Instance.Balls;

        foreach (Ball ball in balls)
        {
            for (int i = 0; i < _ballCount; i++)
            {
                Ball newBall = Instantiate(ball);
                newBall.StartBall();
            }
        }
    }

    #endregion
}