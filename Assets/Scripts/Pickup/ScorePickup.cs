using UnityEngine;

public class ScorePickup : PickupBase
{
    #region Variables
    
    [Header("Minor settings")]
    [SerializeField] private int _scoreToAdd;

    #endregion


    #region Private methods

    protected override void ApplyPickup()
    {
        GameManager.Instance.AddScore(_scoreToAdd);
    }

    #endregion
}