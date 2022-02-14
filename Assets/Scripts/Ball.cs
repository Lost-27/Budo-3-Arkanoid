using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    #region Variables

    private const float NUM_RANGE = 1.0f;

    [Header("Base settings")] 
    [SerializeField] private float _speed = 300.0f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _ballPrefab;

    [Header("Pad setting")] 
    [SerializeField] private Transform _startPointBall;
    
    private Pad _pad;

    private bool _isStarted;
    private bool _isTripleBall;

    private float _currentSpeed;
    private Vector3 _startScale;

    private Vector3 _offset;

    #endregion


    #region Properties

    public Rigidbody2D Rb => _rb;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _startScale = transform.localScale;
    }

    private void Start()
    {
        _pad = FindObjectOfType<Pad>();

        if (GameManager.Instance.IsAutoplay)
            AddStartingForce();
    }

    private void Update()
    {
        if (!_isStarted)
        {
            if (!_pad.IsMagnet)
            {
                PositionBallOnPad();
            }
            else
            {
                UpdateBallPosition();
            }

            if (_isTripleBall)
                ChangeToThreeBalls();

            if (IsLBMouseClick())
            {
                AddStartingForce();
            }
        }
    }

    #endregion


    #region Public methods

    public void InitialState()
    {
        _isStarted = false;
        _rb.velocity = Vector2.zero;
        MakeNormalScale();
    }

    public void ChangeSpeed(int speedMultiplier)
    {
        _currentSpeed *= speedMultiplier;
        _rb.AddForce(RandomDirection() * _currentSpeed);
    }

    public void ChangeScale(float sizeModifier, float activeTime)
    {
        transform.localScale = new Vector3(sizeModifier, sizeModifier, 1f);
        Invoke(nameof(MakeNormalScale), activeTime);
    }

    public void MakeNormalScale()
    {
        transform.localScale = _startScale;
    }

    public void StopMovingBall()
    {
        _isStarted = false;
        CalculateOffset();
    }

    public void UpdateBallPosition()
    {
        Vector3 padPosition = _startPointBall.position;
        padPosition -= _offset;
        transform.position = padPosition;
    }
    public void ChangeToThreeBalls()//(float activeTime)
    {
        _isTripleBall = true;
        Vector3 curpos = transform.position;
        curpos.x = transform.position.x;
        curpos.y = transform.position.y;
        for (int i = 0; i < 2; i++)
        {
            curpos.z = transform.position.z+i;
            Vector3 fds = curpos;
            Instantiate(_ballPrefab, fds, Quaternion.identity);
            
            // Invoke(nameof(MakeOneBall), activeTime);
        }
    }

    #endregion


    #region Private methods

    private bool IsLBMouseClick()
    {
        return Input.GetMouseButtonDown(0);
    }

    private void PositionBallOnPad()
    {
        transform.position = _startPointBall.position;
    }

    private void AddStartingForce()
    {
        _currentSpeed = _speed;
        _rb.AddForce(RandomDirection() * _currentSpeed);
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
        _offset = _startPointBall.position - transform.position;
    }

    #endregion

}