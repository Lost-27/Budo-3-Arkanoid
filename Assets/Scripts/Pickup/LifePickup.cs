using UnityEngine;

public class LifePickup : PickupBase
{
    #region Variables
    
    [Header("Minor settings")]
    [SerializeField] private bool _isAddsLives;

    #endregion


    #region Private methods

    protected override void ApplyPickup()
    {
        LiveChange(_isAddsLives);
    }

    private void LiveChange(bool isAddsLives)
    {
        if (isAddsLives)
            GameManager.Instance.AddLive();
        else
            GameManager.Instance.RemoveLive();
    }

    #endregion
}