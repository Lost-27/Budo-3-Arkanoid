public class MagnetPickup : PickupBase
{
    #region Private methods

    protected override void ApplyPickup()
    {
        Pad pad = FindObjectOfType<Pad>();
        pad.ChangeToMagneticPad(_activeTime);
    }

    #endregion
}