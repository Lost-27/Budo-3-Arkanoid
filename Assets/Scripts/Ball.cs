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
    }

    private void Start()
    {
        _pad = FindObjectOfType<Pad>();
        
        _startOffset = _startPointBall.position - _pad.transform.position;
        _currentOffset = _startOffset;

        if (GameManager.Instance.IsAutoplay)
            AddStartingForce();
        
        OnCreated?.Invoke(this);
    }

    private void Update()
    {
        if (_isStarted)
            return;
        
        PositionBallOnPad();
        
        if (IsLBMouseClick())
        {
            AddStartingForce();
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
        _isStarted = false;
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
        AddStartingForce();
    }

    public void StopMovingBall()
    {
        _isStarted = false;
        CalculateOffset();
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

    private void AddStartingForce()
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

    #endregion

}