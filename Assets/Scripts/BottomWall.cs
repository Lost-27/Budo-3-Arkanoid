using UnityEngine.SceneManagement;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Ball))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion
}
