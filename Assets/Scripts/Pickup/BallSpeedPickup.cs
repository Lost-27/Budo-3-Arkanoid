using System.Collections.Generic;
using UnityEngine;

public class BallSpeedPickup : PickupBase
{
    #region Variables

    [SerializeField] private int _speedMultiplier;

    #endregion


    #region Private methods

    protected override void ApplyPickup()
    {
        List<Ball> balls = BallsContainer.Instance.Balls;

        foreach (Ball ball in balls)
        {
            ball.ChangeSpeed(_speedMultiplier);
        }
    }

    #endregion
}