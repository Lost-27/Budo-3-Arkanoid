using UnityEngine;

public class BottomWall : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Ball))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            GameManager.Instance.Lives--;
            ball.MoveBallWithPad();
            ball._isStarted = false;            
        }

        if (GameManager.Instance.Lives <= 0)
        {
            SceneHelper.Instance.LoadScene(2);            
        }
    }

    #endregion
}