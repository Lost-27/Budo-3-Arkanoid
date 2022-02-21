using UnityEngine;

public class PadScalePickup : PickupBase
{
    #region Variables
    
    [Header("Minor settings")]
    [SerializeField] private float _sizeModifier;

    #endregion


    #region Private methods

    protected override void ApplyPickup()
    {
        Pad pad = FindObjectOfType<Pad>();
        pad.ChangeWidth(_sizeModifier);
    }

    #endregion
}
