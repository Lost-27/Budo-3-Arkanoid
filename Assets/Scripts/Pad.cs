using System;
using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _xRange;
    [SerializeField] private float _maxBounceAngle = 75f;

    [Header("Pickup Settings")]
    [SerializeField] private float _minSizePad = 0.3f;
    [SerializeField] private float _maxSizePad = 2f;

    private Vector3 _currenSize;
    private Transform _ballTransform;

    #endregion


    #region Properties

    public bool IsMagnet { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _currenSize = transform.localScale;
    }

    private void Start()
    {
        _ballTransform = FindObjectOfType<Ball>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball == null)
            return;
        CalculateBounceAngle(collision, ball);

        if (IsMagnet)
        {
            ball.StopMovingBall();
        }
    }


    private void Update()
    {
        if (GameManager.Instance.IsAutoplay)
            AutoMovingPad();
        else
            MovingPadWithMouse();
    }

    #endregion


    #region Public methods

    public void ChangeWidth(float sizeModifier)
    {
        _currenSize *= sizeModifier;
        _currenSize.y = 1;
        _currenSize.z = 1;

        if (_currenSize.x < _minSizePad)
        {
            _currenSize.x = _minSizePad;
        }

        if (_currenSize.x > _maxSizePad)
        {
            _currenSize.x = _maxSizePad;
        }

        transform.localScale = _currenSize;
    }

    public void ChangeToMagneticPad(float activeTime)
    {
        IsMagnet = true;
        Invoke(nameof(MakeNormalPad), activeTime);
    }

    public void MakeNormalPad()
    {
        IsMagnet = false;
    }

    #endregion


    #region Private methods

    private void MovingPadWithMouse()
    {
        if (PauseManager.Instance.IsPaused)
            return;

        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(worldPos.x, -_xRange, _xRange);
        transform.position = currentPos;
    }

    private void AutoMovingPad()
    {
        if (PauseManager.Instance.IsPaused)
            return;

        Vector2 ballWorldPos = _ballTransform.position;

        Vector2 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(ballWorldPos.x, -_xRange, _xRange);
        transform.position = currentPos;
    }

    private void CalculateBounceAngle(Collision2D collision, Ball ball)
    {
        Vector2 padPosition = transform.position;
        Vector2 contactPoint = collision.GetContact(0).point;

        float offset = padPosition.x - contactPoint.x;
        float halfWidthPad = collision.otherCollider.bounds.size.x / 2;

        float currentAngle = Vector2.SignedAngle(Vector2.up, ball.Rb.velocity);
        float bounceAngle = (offset / halfWidthPad) * _maxBounceAngle;
        float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -_maxBounceAngle, _maxBounceAngle);

        Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
        ball.SetNewAngularVelocity(rotation);
    }

    #endregion
}