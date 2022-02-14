using UnityEngine;

public abstract class PickupBase : MonoBehaviour
{
    #region Variables

    [SerializeField] protected float _activeTime;

    #endregion


    #region Unity lifecycle

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Pad))
        {
            ApplyPickup();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag(Tags.BottomWall))
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Private methods

    protected abstract void ApplyPickup();

    #endregion
}