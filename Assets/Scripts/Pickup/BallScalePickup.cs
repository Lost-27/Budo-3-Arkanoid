using UnityEngine;

public class BallScalePickup : PickupBase
{
    #region Variables

    [SerializeField] private float _sizeModifier;

    #endregion


    #region Private methods

    protected override void ApplyPickup()
    {
        Ball ball = FindObjectOfType<Ball>();
        ball.ChangeScale(_sizeModifier, _activeTime);
    }

    #endregion
}
