using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    public Sprite[] States;
    public SpriteRenderer SpriteRend;
    public int PointValue;
    public bool IsIndestructible;
    public bool IsInvisible;

    private int _health;

    #endregion


    #region Events

    public static event Action OnCreated;
    public static event Action<Block> OnDestroyed;

    #endregion


    #region Unity lifecycle  
    
    private void Start()
    {
        if (!IsIndestructible)
        {
            _health = States.Length;
            UpdateCurrentState();
            OnCreated?.Invoke();
        }

        if (IsInvisible)
        {
            SpriteRend.enabled = false;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        GetHit();
    }

    #endregion


    #region Private methods

    private void GetHit()
    {
        if (IsIndestructible)
            return;
        
        if (IsInvisible)
        {
            SpriteRend.enabled = true;
            IsInvisible = false;
            return;
        }
        
        _health--;

        if (_health <= 0)
        {
            GameManager.Instance.AddScore(PointValue);
            Destroy(gameObject);
            OnDestroyed?.Invoke(this);
        }
        else
            UpdateCurrentState();                
    }

    private void UpdateCurrentState()
    {
        SpriteRend.sprite = States[_health - 1];
    }

    #endregion
}