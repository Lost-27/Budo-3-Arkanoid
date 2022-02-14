using UnityEngine;

public class BottomWall : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Ball))
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

    #endregion
}