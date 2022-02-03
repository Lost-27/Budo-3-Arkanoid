using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    public Sprite[] States;
    public int PointValue;
        
    [SerializeField] private SpriteRenderer _spriteRend;
        
    private int _health;
    
    #endregion


    #region Unity lifecycle
        
    private void Start()
    {
        _health = States.Length;
        UpdateCurrentState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetHit();
    }

    #endregion


    #region Private methods

    private void GetHit()
    {
        _health--;

        if (_health <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.AddScore(PointValue);            
        }        
        else
            UpdateCurrentState();                
    }

    private void UpdateCurrentState()
    {
        _spriteRend.sprite = States[_health - 1];
    }

    #endregion
}