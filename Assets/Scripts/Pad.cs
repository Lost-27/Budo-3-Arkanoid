using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _xRange;
    [SerializeField] private float _maxBounseAngle = 75f;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 padPosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = padPosition.x - contactPoint.x;
            float halfWidthPad = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.Rb.velocity);
            float bounceAngle = (offset / halfWidthPad) * _maxBounseAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -_maxBounseAngle, _maxBounseAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.Rb.velocity = rotation * Vector2.up * ball.Rb.velocity.magnitude;
        }
    }

    private void Update()
    {
        MovingPadWithMouse();
    }

    #endregion


    #region Private methods

    private void MovingPadWithMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(worldPos);

        Vector2 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(worldPos.x, -_xRange, _xRange);
        transform.position = currentPos;
    }

    #endregion
}