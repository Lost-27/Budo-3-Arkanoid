using UnityEngine;

public abstract class PickupBase : MonoBehaviour
{
    #region Variables

    [SerializeField] protected float _activeTime;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Pad))
        {
            ApplyPickup();
            Destroy(gameObject);
        }
    }

    #endregion


    #region Private methods

    protected abstract void ApplyPickup();

    #endregion
}