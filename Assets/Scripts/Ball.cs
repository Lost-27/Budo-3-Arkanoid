using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    private const float NUM_RANGE = 1.0f;

    [Header("Base settings")]
    [SerializeField] private float _speed = 300.0f;
    [SerializeField] private Rigidbody2D _rb;

    [Header("Pad setting")]
    [SerializeField] private Transform _padTransform;

    private float _yOffsetFromPad = 1.0f;
    private bool _isStarted;    

    #endregion


    #region Properties

    public Rigidbody2D Rb => _rb;

    #endregion


    #region Unity lifecycle      

    private void Update()
    {
        if (_isStarted)
        {
            return;
        }

        MagnetBallToPad();

        if (Input.GetMouseButtonDown(0))
        {
            AddStartingForce();
        }
    }

    #endregion


    #region Public methods

    public void InitialState()
    {
        _isStarted = false;
        _rb.velocity = Vector2.zero;                
    }

    #endregion


    #region Private methods

    private void MagnetBallToPad()
    {
        Vector3 currentPos = _padTransform.position;
        currentPos.y += _yOffsetFromPad;
        transform.position = currentPos;
    }

    private void AddStartingForce()
    {
        _rb.AddForce(RandomDirection() * _speed);
        _isStarted = true;
    }

    private Vector2 RandomDirection()
    {
        float x = Random.Range(-NUM_RANGE, NUM_RANGE);
        float y = NUM_RANGE;

        Vector2 direction = new Vector2(x, y).normalized;
        return direction;
    }
    #endregion
}