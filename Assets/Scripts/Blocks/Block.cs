using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Variables
    
    [Header("Audio")]
    [SerializeField] private AudioClip _audioClip;

    [Header("Base Settings")] 
    [SerializeField] private Sprite[] _states;
    [SerializeField] private SpriteRenderer _spriteRend;
    [SerializeField] private int _pointValue;
    [SerializeField] private bool _isIndestructible;
    [SerializeField] private bool _isInvisible;

    [Header("Pickup settings")] 
    [SerializeField] private GameObject[] _pickupPrefab;

    [Range(0f, 100f)] 
    [SerializeField] private float _pickupChance;

    private int _health;

    #endregion


    #region Events

    public static event Action OnCreated;
    public static event Action<Block> OnDestroyed;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        if (!_isIndestructible)
        {
            _health = _states.Length;
            UpdateCurrentState();
            OnCreated?.Invoke();
        }

        if (_isInvisible)
        {
            _spriteRend.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(Tags.Ball))
            return;

        GetHit();
        ApplyInternalActions();
    }

    #endregion


    #region Private methods

    protected virtual void ApplyInternalActions()
    {
        
    }

    public void GetHit()
    {
        if (_isIndestructible)
            return;

        if (_isInvisible)
        {
            _spriteRend.enabled = true;
            _isInvisible = false;
            return;
        }

        _health--;

        if (_health <= 0)
        {
            GameManager.Instance.AddScore(_pointValue);
            AudioManager.Instance.PlayOnShot(_audioClip);
            Destroy(gameObject);
            CreatePickupIfNeeded();
            OnDestroyed?.Invoke(this);
        }
        else
            UpdateCurrentState();
    }

    private void UpdateCurrentState()
    {
        _spriteRend.sprite = _states[_health - 1];
    }

    private void CreatePickupIfNeeded()
    {
        float randomChance = Random.Range(1f, 100f);

        if (_pickupChance > randomChance)
        {
            Instantiate(GetRandomPickupPrefab(), transform.position, Quaternion.identity);
        }
    }

    private GameObject GetRandomPickupPrefab()
    {
        return _pickupPrefab[Random.Range(0,_pickupPrefab.Length)];
    }

    #endregion
}