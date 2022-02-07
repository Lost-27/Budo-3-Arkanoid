using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    #region Variables

    public GameObject[] Hearts;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (GameManager.Instance.Lives < 1)
        {
            Destroy(Hearts[0]);
        }
        else if (GameManager.Instance.Lives < 2)
        {
            Destroy(Hearts[1]);
        }
        else if (GameManager.Instance.Lives < 3)
        {
            Destroy(Hearts[2]);
        }
    }

    #endregion
}
