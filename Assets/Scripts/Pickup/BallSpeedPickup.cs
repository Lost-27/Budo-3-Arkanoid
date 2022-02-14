using UnityEngine;

public class BallSpeedPickup : PickupBase
{
    #region Variables

    [SerializeField] private int _speedMultiplier;

    #endregion


    #region Private methods

    //???
    protected override void ApplyPickup()
    {
        Ball ball = FindObjectOfType<Ball>();
        ball.ChangeSpeed(_speedMultiplier);
    }

    #endregion
}