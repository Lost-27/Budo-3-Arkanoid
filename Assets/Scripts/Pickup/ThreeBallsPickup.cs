public class ThreeBallsPickup : PickupBase
{
    #region Private methods

    protected override void ApplyPickup()
    {
        Ball ball = FindObjectOfType<Ball>();
        ball.ChangeToThreeBalls();//(_activeTime);
    }

    #endregion
}