using UnityEngine;

public class PadScalePickup : PickupBase
{
    #region Variables

    [SerializeField] private Vector2 _padWidthScaling;

    #endregion


    #region Private methods

    protected override void ApplyPickup()
    {
        Pad pad = FindObjectOfType<Pad>();
        pad.ChangeWidth(_padWidthScaling);
    }

    #endregion
}
