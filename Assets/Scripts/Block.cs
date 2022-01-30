using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    public Sprite[] States;
    public int PointValue;
        
    private SpriteRenderer _spriteRend;
    private GameManager _gameManager;
    private int Health;
    
    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _spriteRend = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Start()
    {
        Health = States.Length;
        Update—urrentState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetHit();
    }

    #endregion


    #region Private methods

    private void GetHit()
    {
        Health--;

        if (Health <= 0)
        {
            Destroy(gameObject);
            _gameManager.UpdateScore(PointValue);
        }
        
        else
            Update—urrentState();
                
    }

    private void Update—urrentState()
    {
        _spriteRend.sprite = States[Health - 1];
    }

    #endregion
}