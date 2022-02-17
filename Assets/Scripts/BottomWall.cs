using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Ball))
        {
            List<Ball> balls = BallsContainer.Instance.Balls;

            if (balls.Count == 1)
            {
                GameManager.Instance.RemoveLive();
                Ball ball = collision.gameObject.GetComponent<Ball>();
                ball.InitialState();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    #endregion
}