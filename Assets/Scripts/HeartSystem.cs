using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    #region Variables

    public GameObject[] Hearts;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i].SetActive(GameManager.Instance.Lives > i);
        }
    }

    #endregion
}
