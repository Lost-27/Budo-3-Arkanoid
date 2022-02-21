using UnityEngine;

public abstract class PickupBase : MonoBehaviour
{
    #region Variables
    
    [Header("Base Settings")] 
    [SerializeField] private int _pointValue;
    [SerializeField] protected float _activeTime;
    
    [Header("Audio")]
    [SerializeField] private AudioClip _pickupClip;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Pad))
        {
            AudioManager.Instance.PlayOnShot(_pickupClip);
            GameManager.Instance.AddScore(_pointValue);
            ApplyPickup();
            Destroy(gameObject);
        }
    }

    #endregion


    #region Private methods

    protected abstract void ApplyPickup();

    #endregion
}