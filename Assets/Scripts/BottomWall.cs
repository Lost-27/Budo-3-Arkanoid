using UnityEngine;

public class BottomWall : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Ball))
        {
            GameManager.Instance.Lives--;
            
            Ball ball = collision.gameObject.GetComponent<Ball>();
            ball.InitialState();
        }

        if (GameManager.Instance.Lives <= 0)
        {
            SceneHelper.Instance.LoadScene(2);            
        }
    }

    #endregion
}