using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    #region Variables

    public float Speed = 300.0f;
    public Transform PadTransform;

    private Rigidbody2D _rb;
    private bool _isStarted;
    private float YOffsetFromPad = 1f;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DownWall"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        _rb.AddForce(RandomDirection() * Speed);
        _isStarted = true;
    }

    private Vector2 RandomDirection()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = 1f;

        Vector2 direction = new Vector2(x, y);
        return direction.normalized;
    }

    private void MoveBallWithPad()
    {
        Vector3 currentPos = PadTransform.position;
        currentPos.y += YOffsetFromPad;
        transform.position = currentPos;
    }

    #endregion
}