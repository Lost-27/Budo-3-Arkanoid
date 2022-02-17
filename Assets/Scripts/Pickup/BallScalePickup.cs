using System.Collections.Generic;
using UnityEngine;

public class BallScalePickup : PickupBase
{
    #region Variables

    [SerializeField] private float _sizeModifier;

    #endregion


    #region Private methods

    protected override void ApplyPickup()
    {
        List<Ball> balls = BallsContainer.Instance.Balls;

        foreach (Ball ball in balls)
        {
            ball.ChangeScale(_sizeModifier, _activeTime);
        }
    }

    #endregion
}