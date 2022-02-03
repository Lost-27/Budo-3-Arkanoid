using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    private const float _numRange = 1.0f;

    [Header("Base settings")]
    [SerializeField] private float _speed = 300.0f;
    [SerializeField] private Rigidbody2D _rb;

    [Header("Pad setting")]
    [SerializeField] private Transform _padTransform;

    private float YOffsetFromPad = 1.0f;
    private bool _isStarted;

    #endregion


    #region Properties

    public Rigidbody2D Rb => _rb;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Lives
    }

    private void Update()
    {
        if (_isStarted)
        {
            return;
        }

        MoveBallWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            AddStartingForce();
        }
    }

    #endregion


    #region Private methods

    private void AddStartingForce()
    {
        _rb.AddForce(RandomDirection() * _speed);
        _isStarted = true;
    }

    private Vector2 RandomDirection()
    {
        float x = Random.Range(-_numRange, _numRange);
        float y = _numRange;

        Vector2 direction = new Vector2(x, y).normalized;
        return direction;
    }

    private void MoveBallWithPad()
    {
        Vector3 currentPos = _padTransform.position;
        currentPos.y += YOffsetFromPad;
        transform.position = currentPos;
    }

    #endregion
}