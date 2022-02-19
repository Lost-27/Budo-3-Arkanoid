using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    #region Variables

    private const float NUM_RANGE = 1.0f;

    [Header("Base settings")] 
    [SerializeField] private float _speed = 300.0f;
    [SerializeField] private Rigidbody2D _rb;

    [Header("Pad setting")] 
    [SerializeField] private Transform _startPointBall;
    
    private Pad _pad;

    private bool _isStarted;

    private float _currentSpeed;
    private Vector3 _startScale;
    private Vector3 _currenScale;

    private Vector3 _startOffset;
    private Vector3 _currentOffset;

    private List<float> _sizeModifiers = new List<float>();
    
    [Header("Explosive ball setup")]
    [SerializeField] private SpriteRenderer _ballRend;
    [SerializeField] private TrailRenderer _trailRend;
    [SerializeField] private Sprite _explosiveBallSp;
    [SerializeField] private Gradient _explosiveTrail;
    [SerializeField] private LayerMask _layerMask;
    
    public bool _isExplosive;
    
    private float _explosionRadius;
    private Sprite _baseSprite;
    private Gradient _baseTrail;
    

    #endregion
    

    #region Events

    public static event Action<Ball> OnCreated;
    public static event Action<Ball> OnDestroyed;

    #endregion


    #region Properties

    public Rigidbody2D Rb => _rb;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _startScale = transform.localScale;
        _currenScale = _startScale;
        _baseSprite = _ballRend.sprite;
        _baseTrail = _trailRend.colorGradient;
    }

    private void Start()
    {
        _pad = FindObjectOfType<Pad>();
        
        _startOffset = _startPointBall.position - _pad.transform.position;
        _currentOffset = _startOffset;

        if (GameManager.Instance.IsAutoplay)
            BallLaunch();
        
        OnCreated?.Invoke(this);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Block))
        {
            if(_isExplosive)
                ExplosiveBall();
        }
        
    }

    private void Update()
    {
        if (_isStarted)
            return;
        
        PositionBallOnPad();
        
        if (IsLBMouseClick())
        {
            BallLaunch();
        }
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

    #endregion


    #region Public methods

    public void InitialState()
    {
        _ballRend.sprite = _baseSprite;
        _trailRend.colorGradient = _baseTrail;
        _isStarted = false;
        _isExplosive = false;
        _rb.velocity = Vector2.zero;
        _currentOffset = _startOffset;
        MakeNormalScale();
    }

    public void SetNewAngularVelocity(Quaternion rotation)
    {
        Rb.velocity = rotation * Vector2.up * Rb.velocity.magnitude;
    }

    public void ChangeSpeed(int speedMultiplier)
    {
        _currentSpeed *= speedMultiplier;
        _rb.velocity = RandomDirection() * _currentSpeed;;
    }

    public void ChangeScale(float sizeModifier, float activeTime)
    {
        _currenScale *= sizeModifier;
        _currenScale.z = 1;
        transform.localScale = _currenScale;
        _sizeModifiers.Add(sizeModifier);
        
        Invoke(nameof(ReturnPreviousScale), activeTime);
    }

    public void MakeNormalScale()
    {
        transform.localScale = _startScale;
    }

    public void ReturnPreviousScale()
    {
        transform.localScale = _currenScale / _sizeModifiers[0];
        _sizeModifiers.RemoveAt(0);
    }

    public void StartBall()
    {
        BallLaunch();
    }

    public void StopMovingBall()
    {
        _isStarted = false;
        CalculateOffset();
    }
    public void SetExplosionRadius(float explosionRadius)
    {
        _isExplosive = true;
        _ballRend.sprite = _explosiveBallSp;
        _trailRend.colorGradient = _explosiveTrail;
        _explosionRadius = explosionRadius;
    }

    #endregion


    #region Private methods

    private bool IsLBMouseClick()
    {
        return Input.GetMouseButtonDown(0);
    }

    private void PositionBallOnPad()
    {
        transform.position = _pad.transform.position + _currentOffset;
    }

    private void BallLaunch()
    {
        _currentSpeed = _speed;
        _rb.velocity = RandomDirection() * _currentSpeed;
        _isStarted = true;
    }

    private Vector2 RandomDirection()
    {
        float x = Random.Range(-NUM_RANGE, NUM_RANGE);
        float y = NUM_RANGE;

        Vector2 direction = new Vector2(x, y).normalized;
        return direction;
    }

    private void CalculateOffset()
    {
        Vector3 newOffset = transform.position - _pad.transform.position;
        newOffset.y = _startOffset.y;
        _currentOffset = newOffset;
    }

    private void ExplosiveBall()
    {
        // _isExplosive = true;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,  _explosionRadius, _layerMask);

        foreach (Collider2D col in colliders)
        {
            Debug.Log($"Name{col.gameObject.name}");
            if (col.gameObject == gameObject)
                continue;
            
            Block des = col.gameObject.GetComponent<Block>(); //?
            des.GetHit();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

    #endregion
}