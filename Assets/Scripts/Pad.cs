using System;
using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _xRange;
    [SerializeField] private float _maxBounseAngle = 75f;
    private Transform _ballTransform;

    #endregion


    #region Properties

    public bool IsMagnet { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _ballTransform = FindObjectOfType<Ball>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball == null)
            return;
        Vector2 padPosition = transform.position;
        Vector2 contactPoint = collision.GetContact(0).point;

        float offset = padPosition.x - contactPoint.x;
        float halfWidthPad = collision.otherCollider.bounds.size.x / 2;

        float currentAngle = Vector2.SignedAngle(Vector2.up, ball.Rb.velocity);
        float bounceAngle = (offset / halfWidthPad) * _maxBounseAngle;
        float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -_maxBounseAngle, _maxBounseAngle);

        Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
        ball.Rb.velocity = rotation * Vector2.up * ball.Rb.velocity.magnitude;
        
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

    public void ChangeWidth(Vector2 padWidthScaling)
    {
        transform.localScale = padWidthScaling;
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

    #endregion
}