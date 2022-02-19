using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBallPickup : PickupBase
{
    #region Variables

    [SerializeField] private float _explosionRadius;

    #endregion


    #region Private methods

    protected override void ApplyPickup()
    {
        List<Ball> balls = BallsContainer.Instance.Balls;

        foreach (Ball ball in balls)
        {
            ball.SetExplosionRadius(_explosionRadius);
        }
    }

    #endregion
}