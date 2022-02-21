using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBallPickup : PickupBase
{
    #region Variables
    
    [Header("Minor settings")]
    [SerializeField] private float _explosionRadius;

    #endregion


    #region Private methods

    protected override void ApplyPickup()
    {
        List<Ball> balls = BallsContainer.Instance.Balls;

        foreach (Ball ball in balls)
        {
            ball.SetExplosionBall(_explosionRadius);
        }
    }

    #endregion
}